using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountEndPointController : ControllerBase
    {
        [HttpGet("GetUserInfo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUserInfo()
        {
            // Lấy token từ HTTP Context
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Giải mã token
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            // Kiểm tra nếu token không tồn tại hoặc không hợp lệ
            if (jwtToken == null)
            {
                return Unauthorized("Invalid token.");
            }

            // Lấy thông tin người dùng từ các claim
            var id = jwtToken.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
            var username = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserName")?.Value;
            var phoneNumber = jwtToken.Claims.FirstOrDefault(c => c.Type == "PhoneNumber")?.Value;
            var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;
            var permission = jwtToken.Claims.FirstOrDefault(c => c.Type == "Permission")?.Value;

            // Tạo object chứa thông tin người dùng
            var userInfo = new
            {
                Id = id,
                UserName = username,
                PhoneNumber = phoneNumber,
                Email = email,
                Permission = permission
            };

            // Trả về thông tin người dùng
            return Ok(userInfo);
        }
    }
}
