using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FrontCrossyTec.Model;

namespace FrontCrossyTec.Pages
{
    public class IndexModel : PageModel
    {
       
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            HttpResponseMessage response = await _apiService.LoginAsync(Email, Password);

            if (response.IsSuccessStatusCode)
            {
                // El inicio de sesión fue exitoso, redirige al usuario al menú principal
                return RedirectToPage("PaginaMenu");
            }
            else
            {
                // El inicio de sesión falló, muestra un mensaje de error
                ModelState.AddModelError(string.Empty, "Inicio de sesión fallido. Revisa tus credenciales.");
                return Page();
            }

        }
    }
}
