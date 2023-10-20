using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FrontCrossyTec.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string LoginEmail { get; set; }

        [BindProperty]
        public string LoginPassword { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (LoginEmail == "pepito@hotmail.com" && LoginPassword == "123")
            {
                // Redirige a la página de registro si las credenciales son correctas.
                return RedirectToPage("PaginaRegistro");
            }
            else
            {
                // Muestra un mensaje de error si las credenciales son incorrectas.
                ErrorMessage = "Credenciales inválidas";
                return Page();
            }
        }
    }
}
