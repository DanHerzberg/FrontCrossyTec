using System;
using System.Threading.Tasks;
using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontCrossyTec.Pages
{
    public class PaginaPerfilModel : PageModel
    {
        private readonly ApiService _apiService;

        public User UserData { get; private set; }
        public int UserAge { get; private set; } // Propiedad para la edad del usuario

        public PaginaPerfilModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            UserData = await _apiService.GetUserInfoAsync();
            UserAge = CalculateAge(UserData.BirthDate); // Calcular la edad
        }

        private int CalculateAge(DateTimeOffset birthDate)
        {
            var today = DateTime.UtcNow;
            var age = today.Year - birthDate.Year;

            // Si aún no ha llegado el cumpleaños de este año, restar un año.
            if (birthDate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
