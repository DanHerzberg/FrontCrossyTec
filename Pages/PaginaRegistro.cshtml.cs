using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FrontCrossyTec.Pages
{
    public class PaginaRegistroModel : PageModel
    {
        private readonly ApiService _apiService;

        public PaginaRegistroModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var registroUsuario = new RegistroUsuario
            {
                name = Request.Form["nombre"],
                last_name = Request.Form["apellido"],
                email = Request.Form["email"],
                gamertag = Request.Form["gamertag"],
                password = Request.Form["password"],
                birth_date = DateTime.Parse(Request.Form["birthdate"]),
                gender = Request.Form["gender"],
                state = Request.Form["estado"],
                coins = 0,
                rol = "Player"
            };

            bool registroExitoso = await _apiService.RegisterAsync(registroUsuario);

            if (registroExitoso)
            {
                // Registro exitoso
                return RedirectToPage("PaginaMenu");
            }
            else
            {
                // Registro fallido
                ModelState.AddModelError(string.Empty, "Error en el registro. Por favor, inténtalo nuevamente.");
                return Page();
            }
        }
    }
}
