using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontCrossyTec.Pages
{
    public class PaginaRegistroModel : PageModel
    {
        public IActionResult OnPost()
        {
            // Aquí procesas los datos del formulario
            // Por ejemplo, puedes recuperar los valores así:
            
            // ...y así sucesivamente para otros campos

            // Luego, rediriges a la página que desees. Por ejemplo, a una página de éxito:
            return RedirectToPage("PaginaMenu");
        }
    }
}
