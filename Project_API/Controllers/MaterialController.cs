using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Bussiness.IServices;
using Project_Bussiness.Payloads.RequestModel;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialServices _service;
        public MaterialController(IMaterialServices service)
        {
            _service = service;
        }
        [HttpPost("AddNewMaterial")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddNewCategory([FromBody] MaterialRequest request)
        {
            return Ok(await _service.AddNewMaterial(request));

        }
        [HttpPut("UpdateMaterial")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateCategory([FromBody] MaterialRequest request, int id)
        {
            return Ok(await _service.Update(id, request));
        }

        [HttpGet("GetAllMaterial")]
        
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await _service.GetAll());
        }


      

        /* [HttpGet("GetById/{id}")]
         public async Task<IActionResult> GetById([FromRoute] int id)
         {
             return Ok(_service.GetById(id));
         }*/
        /*[HttpGet("GetById/{id}")]
        public  IActionResult GetById([FromRoute] int id)
        {
            return Ok(_service.GetById(id));
        }*/

        [HttpDelete("DeleteMaterialById/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            return Ok(await _service.Delete(id));
        }

    }
}
