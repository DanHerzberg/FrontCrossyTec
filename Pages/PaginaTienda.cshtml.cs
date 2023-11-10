using System.Collections.Generic;
using System.Threading.Tasks;
using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace FrontCrossyTec.Pages
{
    public class PaginaTiendaModel : PageModel
    {
        public List<Chest> cajas { get; private set; }

        public async Task OnGetAsync()
        {
            var apiService = new ApiService(new HttpClient());

            try
            {
                cajas = await apiService.GetChestsAsync();
            }
            catch (Exception ex)
            {
                // Manejar errores aquí según tus necesidades
            }
        }
    }
}