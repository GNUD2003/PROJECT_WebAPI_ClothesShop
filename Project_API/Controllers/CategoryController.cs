using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Bussiness.IServices;
using Project_Bussiness.Payloads.RequestModel;
using Project_Bussiness.Payloads.RequestModel.UserRequest;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategorieServices _service;
        public CategoryController(ICategorieServices service)
        {
            _service = service;
        }
        [HttpPost("AddNewCategory")]

     /*   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]*/
        public async Task<IActionResult> AddNewCategory([FromBody] CategoryRequest request)
        {
            return Ok(await _service.AddNewCategory(request));

        }
        [HttpPut("UpdateCategory")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryRequest request,int id)
        {
           return Ok( await _service.Update(id,request));
        }

        [HttpGet("GetAllCategory")]
        
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await _service.GetAll());
        }
        /*
                [HttpGet("GetById")]
                public async Task<IActionResult> GetById([FromBody] int id)
                {
                    return Ok(_service.GetById(id));
                }*/

        [HttpGet("GetById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpDelete("DeleteCategoryById/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            return Ok(await _service.Delete(id));
        }

    }
}
