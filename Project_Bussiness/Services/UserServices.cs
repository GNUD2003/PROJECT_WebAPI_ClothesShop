using Project_Bussiness.IServices;
using Project_Bussiness.Page;
using Project_Data.Data;
using Project_Model.Entities;
using Project_Model.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Services
{
    public class UserServices : IUserServices
    {
        private readonly IDBContext _dbContext;

        private readonly IBaseRepositoty<User> _userRepository;

        public UserServices() { }
        public UserServices(IDBContext dbContext, IBaseRepositoty<User> userRepository) 
        { 
            _dbContext = dbContext;
            _userRepository = userRepository;
        
        }

        public async Task<PageResult<User>> GetAllPaging(string? keyword, Pagination pagination)
        {
            var list1 = await _userRepository.GetAllAsync();
            var list = list1.Where(user => user.UserStatus == UserStatuss.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                list = list.Where(x => x.UserName.ToLower().Contains(keyword.ToLower()));
            }
            pagination.TotalCount = list.Count();
            
            var result = PageResult<User>.ToPageResult(pagination, list);
            return new PageResult<User>(pagination, result);
        }
        public async Task<PageResult<User>> GetAllBlockPaging(string? keyword, Pagination pagination)
        {

            var list1 = await _userRepository.GetAllAsync();
            var list = list1.Where(user => user.UserStatus == UserStatuss.UnActive);
            if (!string.IsNullOrEmpty(keyword))
            {
                list = list.Where(x => x.UserName.ToLower().Contains(keyword.ToLower()));
            }
            pagination.TotalCount = list.Count();

            var result = PageResult<User>.ToPageResult(pagination, list);
            return new PageResult<User>(pagination, result);
        }

        public async Task<string> Delete(int id)
        {
            var product = await _userRepository.GetByIdAsync(id);

            if (product == null)
            {
                return "User not exist";
            }

            product.UserStatus = 0;

            await _userRepository.UpdateASync(product);

            return "Block Successfully";
        }

        public async Task<string> Authen(int id)
        {
            var product = await _userRepository.GetByIdAsync(id);

            if (product == null)
            {
                return "User not exist";
            }

            product.UserStatus = UserStatuss.Active;

            await _userRepository.UpdateASync(product);

            return "Authentication Successfully";
        }
    }
}
