using Microsoft.AspNetCore.Mvc;
using PruebaSTJuanTrejo.Business.Services.Auth;
using PruebaSTJuanTrejo.Business.Services.Stores;
using PruebaSTJuanTrejo.Controllers.Models;
using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("/Auth/Login")]
        public IActionResult Login(
            [FromBody] LoginInformation login
            )
        {

            var result = _authService.Login(login.Email, login.Password);
            return new JsonResult(result);
        }

        
    }
}
