using Project_Bussiness.Page;
using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.IServices
{
    public interface IUserServices
    {
        Task<PageResult<User>> GetAllPaging(string? keyword, Pagination pagination);
        Task<PageResult<User>> GetAllBlockPaging(string? keyword, Pagination pagination);


        Task<string> Delete(int id);
        Task<string> Authen(int id);
    }
}
