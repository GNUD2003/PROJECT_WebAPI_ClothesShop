using Microsoft.EntityFrameworkCore;
using Project_Data.Data;
using Project_Model.Entities;
using Project_Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        #region

        private Task<bool> CompareString(string str1, string str2)
        {
            return Task.FromResult(string.Equals(str1.ToLowerInvariant(), str2.ToLowerInvariant()));
        }
        private async Task<bool> IsStringInListAsync(string input, List<string> listString)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if (listString == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            foreach (string str in listString)
            {
                if (await CompareString(input, str))
                {
                    return true;
                }
            }
            return false;

        }
        #endregion
        public async Task AddRolesToUserAsync(User user, List<string> listRoles)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (listRoles == null)
            {
                throw new ArgumentNullException(nameof(listRoles));
            }
            foreach (string role in listRoles.Distinct())
            {
                var roleOfUser = await GetRolesOfUserAsync(user);
                if (await IsStringInListAsync(role, roleOfUser.ToList()))
                {
                    throw new ArgumentException("Nguoi dung da co quyen nay");
                }
                else
                {
                    var roleItem = await _context.Roles.SingleOrDefaultAsync(x => x.RoleCode.Equals(role));
                    if (roleItem == null)
                    {
                        throw new ArgumentException("Nguoi dung khong co quyen nay");
                    }
                    _context.Permissions.Add(new Permission
                    {
                        RoleId = roleItem.Id,
                        UserId = user.Id,
                    });
                }
            }
            _context.SaveChanges();
        }

        public async Task<IEnumerable<string>> GetRolesOfUserAsync(User user)
        {
            var roles = new List<string>();
            var listRoles = _context.Permissions.Where(x => x.Id == user.Id).AsQueryable();
            foreach (var item in listRoles.Distinct())
            {
                var role = await _context.Roles.SingleOrDefaultAsync(x => x.Id == item.RoleId);
                roles.Add(role.RoleCode);
            }
            return roles.AsQueryable();

        }

        public async Task<User> GetUserByEmail(string email)
        {
            var check = _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            return await check;
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            var check = _context.Users.SingleOrDefaultAsync(x => x.PhoneNumber.ToLower().Equals(phone.ToLower()));
            return await check;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var check = _context.Users.SingleOrDefaultAsync(x => x.UserName.ToLower().Equals(username.ToLower()));
            return await check;
        }
    }
}

