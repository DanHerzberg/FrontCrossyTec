using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FrontCrossyTec.Pages
{
    public class PruebaaaModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }
        // Agrega más propiedades según los datos de sesión que desees mostrar

        public PruebaaaModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            UserId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName");
            UserEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail"); // Obtiene el correo electrónico de la sesión

            // Obten más datos de sesión según tus necesidades
        }
    }
}
