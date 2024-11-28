using Project_Bussiness.Payloads.RequestModel;
using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.IServices
{
    public interface ICategorieServices
    {
        Task<string> AddNewCategory(CategoryRequest request);
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);

        Task<string> Update(int id, CategoryRequest request);
        Task<string> Delete(int id);
    }
}
