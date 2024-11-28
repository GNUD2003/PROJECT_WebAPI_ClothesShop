using Project_Bussiness.Payloads.RequestModel;
using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.IServices
{
    public interface IMaterialServices
    {
        Task<string> AddNewMaterial(MaterialRequest request);
        Task<IEnumerable<Materials>> GetAll();
        Task<Materials> GetById(int id);

        Task<string> Update(int id, MaterialRequest request);
        Task<string> Delete(int id);

    }
}
