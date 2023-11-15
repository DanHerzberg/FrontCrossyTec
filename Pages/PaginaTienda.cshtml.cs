using System.Collections.Generic;
using System.Threading.Tasks;
using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Http; // Agregar este using para IHttpContextAccessor
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontCrossyTec.Pages
{
    public class PaginaTiendaModel : PageModel
    {
        public List<Chest> cajas { get; private set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaginaTiendaModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task OnGetAsync()
        {
            var apiService = new ApiService(new HttpClient(), _httpContextAccessor);

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
