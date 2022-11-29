using AXA_DemoAPI.DTO;
using AXA_DemoAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AXA_DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenManager tokenManager;

        public AuthController(TokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }

        [HttpPost]
        public IActionResult Login(UserLogin form)
        {
            string token = tokenManager.GenerateToken(form);

            return Ok(token);
        }
    }
}
