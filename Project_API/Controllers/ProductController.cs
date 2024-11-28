using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Bussiness.IServices;
using Project_Bussiness.Page;
using Project_Bussiness.Payloads.RequestModel;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _service;
        public ProductController(IProductServices service)
        {
            _service = service;
        }

        [HttpPost("AddNewProductByCateId/{cateId}MateId/{mateId}")]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddNewProduct([FromRoute] int mateId, [FromRoute] int cateId, [FromBody] ProductRequest request)
        {
            return Ok(await _service.AddNewProduct(cateId, mateId, request));
        }

        [HttpPut("UpdateProduct")]

      /*  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]*/
        public async Task<IActionResult> UpdateProduct([FromBody] ProductRequest request, int id)
        {
            return Ok(await _service.Update(id, request));
        }

        [HttpGet("GetAllProduct")]
       
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _service.GetAll());
        }


        [HttpGet("GetAllProductByCategory/{id}")]

        public async Task<IActionResult> GetAllByCategory([FromRoute] int id)
        {
            return Ok(await _service.GetAllProductByCategory(id));
        }

        [HttpGet("GetAllProductByMaterial/{id}")]

        public async Task<IActionResult> GetAllByMaterial([FromRoute] int id)
        {
            return Ok(await _service.GetAllProductByMategory(id));
        }

        [HttpGet("Lay-Danh-Sch-Phan-Trang")]
       public async Task<IActionResult> GetListPage([FromQuery] string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(await _service.GetAllPaging(keyword, pagination));
        }


        [HttpGet("Lay-Danh-Sch-Phan-Trang-SoldOut")]
        public async Task<IActionResult> GetListPageSoldOut([FromQuery] string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(await _service.GetAllPagingSoldOut(keyword, pagination));
        }




        /*[HttpDelete("DeleteProductById/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            return Ok(await _service.Delete(id));
        }*/
        [HttpPut("DeleteProductById/{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut("BackOnSaleProductById/{id}")]
        public async Task<IActionResult> BackOnSale([FromRoute] int id)
        {
            return Ok(await _service.BackOnSale(id));
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _service.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }
        [HttpGet("GetBestCountOfProducts")]
        public async Task<IActionResult> GetBestCountOfProducts()
        {
            var products = await _service.GetTop8BestSellingProducts();
            if (products == null || !products.Any())
            {
                return NotFound("No products found");
            }
            return Ok(products);
        }

    }
}
