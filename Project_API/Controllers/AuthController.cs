using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Bussiness.IServices;
using Project_Bussiness.Payloads.RequestModel.UserRequest;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _service;
        public AuthController(IAuthServices service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Request_Register request)
        {
            return Ok(await _service.Register(request));

        }
        [HttpPost("CheckEmail")]
        public async Task<IActionResult> ConfirmRegisterAccount(string confirmCode)
        {
            return Ok(await _service.ConfirmRegisterAccount(confirmCode));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Request_Login request)
        {
            return Ok(await _service.Login(request));
        }


        [HttpPut("ChangePassword")]

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePassword([FromBody] Request_ChangePassword request)
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _service.ChangePassword(id, request));
        }
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            return Ok(await _service.ForgotPassWord(email));
        }

        [HttpPut("NewPassword")]
        public async Task<IActionResult> ConfirmCreateNewPassword([FromBody] Request_CreateNewPassWord request)
        {
            return Ok(await _service.ConfirmCreateNewPassWord(request));
        }

        [HttpPost("UserID/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddRolesToUser([FromRoute] int id, [FromBody] List<string> roles)
        {
            return Ok(await _service.AddRolesToUser(id, roles));
        }
    }
}
