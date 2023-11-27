using ITDeskServer.WebAPI.DTOs;
using ITDeskServer.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITDeskServer.WebAPI.Controllers
{
    // AuthController, kullanıcı kaydı ve girişi işlemlerini yöneten API denetleyicisidir.
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        // AuthController sınıfını oluşturan yapıcı metod.
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // Kullanıcı kaydı için HTTP POST isteğine yanıt veren eylem.
        [HttpPost]
        public IActionResult Register(RegisterDto request)
        {
            // AuthService sınıfındaki Register metodu kullanılarak kullanıcı kaydı gerçekleştirilir.
            _authService.Register(request);
            // HTTP 204 No Content yanıtı döndürülür (başarı durumu, içerik olmadan).
            return NoContent();
        }

        // Kullanıcı girişi için HTTP POST isteğine yanıt veren eylem.
        [HttpPost]
        public IActionResult Login(LoginDto request)
        {
            // AuthService sınıfındaki Login metodu kullanılarak kullanıcı girişi gerçekleştirilir.
            string token = _authService.Login(request);
            // HTTP 200 OK yanıtı ile birlikte oluşturulan erişim token'ı döndürülür.
            return Ok(new { AccessToken = token });
        }
    }
}
