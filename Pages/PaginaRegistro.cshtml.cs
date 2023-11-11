using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


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
            RegistroUsuario registroUsuario = new RegistroUsuario
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

            HttpResponseMessage response = await _apiService.RegisterAsync(registroUsuario);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("PaginaMenu");
            }
            else
            {
                var errorResult = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error en el registro: {errorResult}");

                return Page();
            }
        }
    }
}
