using Project_Bussiness.IServices;
using Project_Bussiness.Page;
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
    public class ProductServices : IProductServices
    {
        private readonly IDBContext _dbContext;
        
        private readonly IBaseRepositoty<Materials> _mateRepository;
        private readonly IBaseRepositoty<Category> _cateRepository;
        private readonly IBaseRepositoty<Product> _productRepository;

        public ProductServices()
        {

        }
        public ProductServices(IDBContext dbContext, IBaseRepositoty<Materials> mateRepository, IBaseRepositoty<Category> cateRepository, 
            IBaseRepositoty<Product> productRepository)
        {
            _dbContext = dbContext;
            _mateRepository = mateRepository;
            _cateRepository = cateRepository;
            _productRepository = productRepository;
        }

        public async Task<string> AddNewProduct(int cateId, int mateId, ProductRequest request)
        {
            var checkMate= await _mateRepository.GetByIdAsync(mateId);
            if( checkMate != null)
            {
                var checkCate = await _cateRepository.GetByIdAsync(cateId);
                if( checkCate != null)
                {
                    Product product = new Product()
                    {
                        name = request.name,
                        price = request.price,
                        description = request.description,
                        CateId = cateId,
                        MateId = mateId,
                    };
                    await _productRepository.CreateAsync(product);
                    return "Them san pham thanh cong";
                }
                else
                {
                    return "The loai san pham chua ton tai";
                }
            }
            else
            {
                return "Chat lieu san pham chua ton tai";
            }

        }

        /* public async Task<string> Delete(int id)
           {
               await _productRepository.DeleteAsync(id);
               return "Xoa thanh cong";
           }*/

        public async Task<string> Delete(int id)
        {
            var product= await _productRepository.GetByIdAsync(id);
         
            if(product == null )
            {
                return "San pham khong ton tai";
            }

            product.IsActive = 0;

            await _productRepository.UpdateASync(product);

            return "Xoa san pham thanh cong";
        }

        public async Task<string> BackOnSale(int id)
        {

            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return "San pham khong ton tai";
            }

            product.IsActive = 1;

            await _productRepository.UpdateASync(product);

            return "San pham duoc ban tro lai";
        }



        /*   public async Task<Materials> GetById(int id)
           {
               var check = await _mateRepository.GetByIdAsync(id);
               // return $"Lay san pham theo : {id} thanh cong ";
               return check;
           }*/

        public async Task<string> Update(int id, ProductRequest request)
        {
            var check = await _productRepository.GetAsync(x => x.Id == id);
            if (check == null)
            {
                return " San pham khong ton tai ";
            }
            else
            {
                check.name = request.name;
                check.price= request.price;
                check.description = request.description;

               await _productRepository.UpdateASync(check);
                return "Update thanh cong";
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            // Lấy toàn bộ danh sách từ repository
            var list = await _productRepository.GetAllAsync();

            // Lọc các sản phẩm có IsActive = 1
            return list.Where(product => product.IsActive == 1);
        }

        public async Task<IEnumerable<Product>> GetAllProductByCategory(int cateId)
        {
            var list1=await _productRepository.getByCategoryIdAsync(cateId);
            var list = list1.Where(product => product.IsActive == 1);
            return list;
        }

        public async Task<IEnumerable<Product>> GetAllProductByMategory(int cateId)
        {
            var list1 = await _productRepository.getByMaterialIdAsync(cateId);
            var list = list1.Where(product => product.IsActive == 1);
            return list;
        }

        public async Task<PageResult<Product>> GetAllPaging(string? keyword, Pagination pagination)
        {
            var list1 = await _productRepository.GetAllAsync();
            var list=list1.Where(product => product.IsActive == 1);

            if (!string.IsNullOrEmpty(keyword))
            {
                list=list.Where(x=>x.name.ToLower().Contains(keyword.ToLower()));
            }
            pagination.TotalCount= list.Count();
            var result = PageResult<Product>.ToPageResult(pagination, list);
            return  new PageResult<Product>(pagination,result);
        }

        public async Task<PageResult<Product>> GetAllPagingSoldOut(string? keyword, Pagination pagination)
        {
            var list1 = await _productRepository.GetAllAsync();
            var list = list1.Where(product => product.IsActive == 0);

            if (!string.IsNullOrEmpty(keyword))
            {
                list = list.Where(x => x.name.ToLower().Contains(keyword.ToLower()));
            }
            pagination.TotalCount = list.Count();
            var result = PageResult<Product>.ToPageResult(pagination, list);
            return new PageResult<Product>(pagination, result);
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return product;
        }
        public async Task<IEnumerable<Product>> GetTop8BestSellingProducts()
        {

            var list = await _productRepository.GetAllAsync();

            var top8Products = list
                .Where(product => product.IsActive == 1)
                .OrderByDescending(product => product.countOfProduct)
                .Take(8);

            return top8Products;
        }
    }
}
