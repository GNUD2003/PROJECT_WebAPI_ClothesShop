using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_Bussiness.Handle.HandleEmail;
using Project_Bussiness.IServices;
using Project_Bussiness.Payloads.Mappers;
using Project_Bussiness.Payloads.RequestModel.UserRequest;
using Project_Bussiness.Payloads.ResponseModel.DataUser;
using Project_Bussiness.Payloads.Responses;
using Project_Bussiness.Validations;
using Project_Data.Data;
using Project_Model.Entities;
using Project_Model.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;


namespace Project_Bussiness.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IBaseRepositoty<User> _baseRepository;
        private readonly UserConverter _userConverter;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IEmailServices _emaiServices;
        private readonly IBaseRepositoty<ConfirmEmail> _baseEmailRepositoty;
        private readonly IBaseRepositoty<Permission> _basePermissionRepository;
        private readonly IBaseRepositoty<Role> _baseRoleRepository;
        private readonly IBaseRepositoty<RefreshToken> _baseRefreshTokenRepository;
        private readonly IDBContext _dbContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthServices(IMapper mapper, IConfiguration configuration, IBaseRepositoty<User> baseRepositoty, UserConverter userConverter
            , IUserRepository userRepository, IEmailServices emailServices, IBaseRepositoty<ConfirmEmail> baseEmailRepository,
            IBaseRepositoty<Permission> basePermissionRepository, IBaseRepositoty<Role> baseRoleRepository,
            IBaseRepositoty<RefreshToken> baseRefreshTokenRepository, IDBContext dbContext
           , IHttpContextAccessor contextAccessor
            )

        {
            _mapper = mapper;
            _configuration = configuration;
            _baseRepository = baseRepositoty;
            _userConverter = userConverter;
            _userRepository = userRepository;
            _emaiServices = emailServices;
            _baseEmailRepositoty = baseEmailRepository;
            _basePermissionRepository = basePermissionRepository;
            _baseRoleRepository = baseRoleRepository;
            _baseRefreshTokenRepository = baseRefreshTokenRepository;
            _dbContext = dbContext;
            _contextAccessor = contextAccessor;
        }
        public AuthServices()
        {

        }
        public async Task<ResponseObject<DataResponseUser>> Register(Request_Register request)
        {
            try
            {
                if (!Validate.IsValidEmail(request.Email))
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Messege = "Dinh dang email khong hop le",
                        Data = null,
                    };
                }
                if (!Validate.IsValidPhone(request.PhoneNumber))
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Messege = "So dien thoai khong hop le",
                        Data = null,
                    };
                }

                if (await _userRepository.GetUserByEmail(request.Email) != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Messege = "Email da ton tai trong he thong, vui long su dung email khac",
                        Data = null,
                    };

                }
                if (await _userRepository.GetUserByPhone(request.PhoneNumber) != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Messege = "PhoneNumber da ton tai trong he thong, vui long su dung PhoneNumber khac",
                        Data = null,
                    };

                }
                if (await _userRepository.GetUserByUsername(request.UserName) != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Messege = "UserName da ton tai trong he thong, vui long su dung UserName khac",
                        Data = null,
                    };
                }
                var user = new User()
                {
                    Avatar = "https://th.bing.com/th/id/R.9b323c2221be4973332470b4fb7f3859?rik=gUqmPkYo0Elr7g&pid=ImgRaw&r=0",
                    IsActive = true,
                    CreatTime = DateTime.Now,
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    FullName = request.FullName,
                    Password = BCryptNet.HashPassword(request.Password),
                    PhoneNumber = request.PhoneNumber,
                    UserName = request.UserName,
                    UserStatus = UserStatuss.UnActive,
                };
                user = await _baseRepository.CreateAsync(user);
                await _userRepository.AddRolesToUserAsync(user, new List<string> { "User" });

                // Gui email

                ConfirmEmail confirmEmail = new ConfirmEmail
                {

                    ConfirmCode = GenerateCodeActive(),
                    ExpiryTime = DateTime.Now.AddMinutes(2),
                    IsConfirmed = false,
                    UserId = user.Id,
                };
                confirmEmail = await _baseEmailRepositoty.CreateAsync(confirmEmail);

                var message = new EmailMessage(new string[] { request.Email }, "Nhan ma xac nhan tai day: ",
                    $"Ma xac nhan : {confirmEmail.ConfirmCode}");

                var responseMessage = _emaiServices.SendEmmail(message);

                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status201Created,
                    Messege = "Ban da gui yeu cau dang ky, vui long nhan ma xac nhan tai email de dang ky tai khoan",
                    //   Data = _mapper.Map<DataResponseUser>(user),
                    Data = _userConverter.EntityToDTO(user),
                };

            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Messege = "Error" + ex.Message,
                    Data = null,
                };
            }
        }
        private string GenerateCodeActive()
        {
            string str = "DungNguyen_" + DateTime.Now.Ticks.ToString();
            return str;
        }

        public async Task<string> ConfirmRegisterAccount(string confirmCode)
        {
            try
            {
                var code = await _baseEmailRepositoty.GetAsync(x => x.ConfirmCode.Equals(confirmCode));
                if (code == null)
                {
                    return "Ma xac nhan khong hop le";
                }

                var user = await _baseRepository.GetAsync(x => x.Id == code.UserId);
                if (code.ExpiryTime < DateTime.Now)
                {
                    return " Ma xac nhan da het han";
                }
                user.UserStatus = UserStatuss.Active;
                code.IsConfirmed = true;
                await _baseRepository.UpdateASync(user);
                await _baseEmailRepositoty.UpdateASync(code);
                return "Xac nhan dang ky tai khoan thanh cong, tu gio ban co the su dung tai khoan nay de dang nhap";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<ResponseObject<DataResponseLogin>> GetJWTTokenAsync(User user)
        {
            var permissions = await _basePermissionRepository.GetAllAsync(x => x.UserId == user.Id);
            var roles = await _baseRoleRepository.GetAllAsync();
            var authClaims = new List<Claim>
            {
                new Claim("Id",user.Id.ToString()),
                new Claim("UserName",user.UserName.ToString()),
                new Claim("PhoneNumber",user.PhoneNumber.ToString()),
                new Claim("Email",user.Email.ToString()),
            };
            foreach (var permission in permissions)
            {
                foreach (var role in roles)
                {
                    if (permission.RoleId == role.Id)
                    {
                        authClaims.Add(new Claim("Permission", role.RoleName));
                    }
                }
            }
            var userRoles = await _userRepository.GetRolesOfUserAsync(user);
            foreach (var item in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, item));
            }
            var jwtToken = GetToken(authClaims);
            var refreshToken = GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidity"], out int refreshTokenValidity);

            RefreshToken refre = new RefreshToken()
            {

                Token = refreshToken,
                ExpiryTime = DateTime.Now.AddHours(refreshTokenValidity),
                UserId = user.Id,

            };
            refre = await _baseRefreshTokenRepository.CreateAsync(refre);
            return new ResponseObject<DataResponseLogin>
            {
                Status = StatusCodes.Status200OK,
                Messege = "Tao thanh cong",
                Data = new DataResponseLogin()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    RefreshToken = refreshToken
                }


            };
        }

        public async Task<ResponseObject<DataResponseLogin>> Login(Request_Login request)
        {
            var check = await _baseRepository.GetAsync(x => x.UserName == request.UserName);
            if (check == null)
            {
                return new ResponseObject<DataResponseLogin>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Messege = "Ten dang nhap khong ton tai",
                    Data = null,
                };
            }

            if (check.UserStatus.ToString().Equals(UserStatuss.UnActive.ToString()))
            {
                return new ResponseObject<DataResponseLogin>
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Messege = "Tai khoan chua duoc xac thuc",
                    Data = null,
                };
            }
            bool checkPass = BCryptNet.Verify(request.Password, check.Password);
            if (!checkPass)
            {
                return new ResponseObject<DataResponseLogin>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Messege = "Mat khau khong chinh xac",
                    Data = null,
                };
            }
            return new ResponseObject<DataResponseLogin>
            {
                Status = StatusCodes.Status200OK,
                Messege = "Dang nhap thanh cong",
                Data = new DataResponseLogin()
                {
                    AccessToken = GetJWTTokenAsync(check).Result.Data.AccessToken,
                    //RefreshToken = GetJWTTokenAsync(check).Result.Data.RefreshToken
                    RefreshToken = GetJWTTokenAsync(check).Result.Data.RefreshToken
                }
            };
        }

        #region Private Methods

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSegniKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInHours"], out int tokenValidityInHours);
            var expirationUTC = DateTime.Now.AddHours(tokenValidityInHours);
            //  var localTimeZone = TimeZoneInfo.Local;
            //  var expirationTimeInLocalTimeZone=TimeZoneInfo.ConvertTimeToUtc(expirationUTC, localTimeZone);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: expirationUTC,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSegniKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new Byte[64];
            var range = RandomNumberGenerator.Create();
            range.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }


        #endregion
        public async Task<ResponseObject<DataResponseUser>> ChangePassword(int UserId, Request_ChangePassword request)
        {
            try
            {
                var checkUser = await _baseRepository.GetByIdAsync(UserId);
                bool checkPas = BCryptNet.Verify(request.OldPassWord, checkUser.Password);
                if (!checkPas)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Messege = "Mat khau khong chinh xac",
                        Data = null
                    };
                }
                if (!request.NewPassWord.Equals(request.ConfirmPassWord))
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Messege = "Mat khau khong trung khop, vui long nhap lai mat khau moi",
                        Data = null
                    };
                }
                checkUser.Password = BCryptNet.HashPassword(request.NewPassWord);
                checkUser.UpdateTime = DateTime.Now;

                await _baseRepository.UpdateASync(checkUser);
                await _dbContext.CommitChangesAsync();
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status200OK,
                    Messege = "Doi mat khau thanh cong",
                    Data = _userConverter.EntityToDTO(checkUser)
                };

            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Messege = ex.Message,
                    Data = null
                };
            }
        }

        public async Task<string> ForgotPassWord(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(email);
                if (user == null)
                {
                    return "Email khong ton tai trong he thong";
                }
                ConfirmEmail confirmEmail = new ConfirmEmail
                {
                    ConfirmCode = GenerateCodeActive(),
                    ExpiryTime = DateTime.Now.AddMinutes(2),
                    UserId = user.Id,
                    IsConfirmed = false
                };
                confirmEmail = await _baseEmailRepositoty.CreateAsync(confirmEmail);
                var message = new EmailMessage(new string[] { user.Email }, "Nhap ma xac nhan tai day : ", $"Ma xac nhan la: {confirmEmail.ConfirmCode}");
                var send = _emaiServices.SendEmmail(message);
                return "Gui ma xac nhan ve email thanh cong ! Vui long kiem tra email ";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> ConfirmCreateNewPassWord(Request_CreateNewPassWord request)
        {
            try
            {
                var confirmEmail = await _baseEmailRepositoty.GetAsync(x => x.ConfirmCode.Equals(request.ConfirmCode));
                if (confirmEmail == null)
                {
                    return "Ma xac nhan khong hop le";
                }
                if (confirmEmail.ExpiryTime < DateTime.Now)
                {
                    return "Ma xac nhan da het han";
                }
                if (!request.NewPassword.Equals(request.ConfirmPassword))
                {
                    return "Mat khau khong trung khop";
                }
                var user = await _baseRepository.GetAsync(x => x.Id == confirmEmail.UserId);
                user.Password = BCryptNet.HashPassword(request.NewPassword);
                user.UpdateTime = DateTime.Now;
                await _baseRepository.UpdateASync(user);
                return "Tao mat khau moi thanh cong";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> AddRolesToUser(int userId, List<string> roles)
        {
            var currentUser = _contextAccessor.HttpContext.User;
            try
            {
                if (currentUser.Identity.IsAuthenticated)
                {
                    return "Nguoi dung chua duoc xac thuc";
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    return "Ban khong co quyen thuc hien chuc nang nay";
                }
                var user = await _baseRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return "Khong rim thay nguoi dung";
                }
                await _userRepository.AddRolesToUserAsync(user, roles);
                return "Them quyen cho nguoi dung thanh cong";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Task<string> DeleteRoles(int userId, List<string> roles)
        {
            throw new NotImplementedException();
        }
    }
}


