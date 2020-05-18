

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Qademli.Models.ViewModel;

namespace Qademli.AreasAPI.AccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        private IConfiguration _config;
        public LoginController(ApplicationDBContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult LoginUser([FromForm]LoginVM login)
        {
            if (ModelState.IsValid)
            {
                
                var user = new LoginViewModel(_db).AuthenticateUser(login);

                if (user != null)
                {
                    var tokenString = new JWTHandler(_config).GenerateJSONWebToken(user);
                    HttpContext.Session.SetString("token", tokenString);
                    return Ok(new { Token = tokenString });
                }

                return Forbid();
            }
            else
            {
                return NotFound();
            }
        }
    }
}