using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Bussiness.IServices;
using Project_Bussiness.Page;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _service;
        public UserController(IUserServices service)
        {
            _service = service;
        }
        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetListPage([FromQuery] string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(await _service.GetAllPaging(keyword, pagination));
        }

        [HttpGet("GetAllBlockStudent")]
        public async Task<IActionResult> GetListBlockPage([FromQuery] string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(await _service.GetAllBlockPaging(keyword, pagination));
        }

        [HttpPut("BlockUserById/{id}")]
        public async Task<IActionResult> BlockByUser([FromRoute] int id)
        {
            return Ok(await _service.Delete(id));
        }


        [HttpPut("AuthenAgainUserById/{id}")]
        public async Task<IActionResult> AuthenUser([FromRoute] int id)
        {
            return Ok(await _service.Authen(id));
        }
    }
}
