using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_Bussiness.Page;
using Project_Bussiness.Payloads.RequestModel;
using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.IServices
{
    public interface IProductServices
    {
        Task<string> AddNewProduct(int cateId, int mateId ,ProductRequest request)
            ;
        Task<string> Update(int id,  ProductRequest request) ;

        Task<IEnumerable<Product>> GetAll();
        Task<string> Delete(int id);

        Task<string> BackOnSale(int id);

        Task<IEnumerable<Product>> GetAllProductByCategory(int cateId);

        Task<IEnumerable<Product>> GetAllProductByMategory(int cateId);

        Task<PageResult<Product>> GetAllPaging(string? keyword, Pagination pagination);

  
       Task<PageResult<Product>> GetAllPagingSoldOut(string? keyword, Pagination pagination);

        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetTop8BestSellingProducts();

    }
}
