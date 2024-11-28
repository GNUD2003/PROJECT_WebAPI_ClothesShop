using Project_Bussiness.IServices;
using Project_Bussiness.Payloads.RequestModel;
using Project_Data.Data;
using Project_Model.Entities;
using Project_Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Services
{
    public class CategoryServices : ICategorieServices
    {
        private readonly IDBContext _dbContext;
       // private readonly IAppDBContext _appDBContext;
        private readonly IBaseRepositoty<Category> _categoryRepository;
        public CategoryServices()
        {

        }
        public CategoryServices(IDBContext dbContext, IBaseRepositoty<Category> categoryRepository)
        {
          _dbContext= dbContext;
          _categoryRepository= categoryRepository;
        // _appDBContext= appDBcontext;
        }

        public async Task<string> AddNewCategory(CategoryRequest request)
        {
            if (request == null)
            {
                return "Yêu cầu không hợp lệ.";
            }
            Category cate = new Category()
            {
                name = request.Name,
            };
            var check = await _categoryRepository.CreateAsync(cate);      
            if (check == null)
            {
                return "Không thể thêm thể loại sản phẩm.";
            }
            return "Thêm thành công thể loại sản phẩm";
        }

        public async Task<string> Delete(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return "Xoa the loai thanh cong";
        }

       

        public async Task<Category> GetById(int id)
        {
            var check= await _categoryRepository.GetByIdAsync(id);
            // return $"Lay san pham theo : {id} thanh cong ";
            return check;
        }

        public async Task<string> Update(int id,CategoryRequest request)
        {
            var check= await _categoryRepository.GetAsync(x=>x.Id == id);
            if (check == null)
            {
                return "khong tim thay the loai ";
            }
            else
            {
                check.name= request.Name;
                _categoryRepository.UpdateASync(check);
                return "Update the loai thanh cong";
            }
        }

        public async Task <IEnumerable<Category>> GetAll()
        {
            var list = await _categoryRepository.GetAllAsync();
            return list;
        }
    }
}
