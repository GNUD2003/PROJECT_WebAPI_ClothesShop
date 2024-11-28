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
    public class MaterialServices : IMaterialServices
    {
        private readonly IDBContext _dbContext;
        // private readonly IAppDBContext _appDBContext;
        private readonly IBaseRepositoty<Materials> _mateRepository;
        public MaterialServices()
        {

        }
        public MaterialServices(IDBContext dbContext, IBaseRepositoty<Materials> mateRepository)
        {
            _dbContext = dbContext;
            _mateRepository = mateRepository;
            // _appDBContext= appDBcontext;
        }

        public async Task<string> AddNewMaterial(MaterialRequest request)
        {
            if (request == null)
            {
                return "Yêu cầu không hợp lệ.";
            }
            Materials cate = new Materials()
            {
                Name = request.Name,
            };
            var check = await _mateRepository.CreateAsync(cate);
            if (check == null)
            {
                return "Không thể thêm chất liêu sản phẩm";
            }
            return "Thêm thành công chất liêu sản phẩm";
        }

        public async Task<string> Delete(int id)
        {
            await _mateRepository.DeleteAsync(id);
            return "Xoa thanh cong";
        }



        public async Task<Materials> GetById(int id)
        {
            var check = await _mateRepository.GetByIdAsync(id);
            // return $"Lay san pham theo : {id} thanh cong ";
            return check;
        }

        public async Task<string> Update(int id, MaterialRequest request)
        {
            var check = await _mateRepository.GetAsync(x => x.Id == id);
            if (check == null)
            {
                return "khong tim thay chat lieu ";
            }
            else
            {
                check.Name = request.Name;
                _mateRepository.UpdateASync(check);
                return "Update thanh cong";
            }
        }

        public async Task<IEnumerable<Materials>> GetAll()
        {
            var list = await _mateRepository.GetAllAsync();
            return list;
        }
    }
}
