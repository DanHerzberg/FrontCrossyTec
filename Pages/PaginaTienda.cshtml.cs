using System.Collections.Generic;
using System.Threading.Tasks;
using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontCrossyTec.Pages
{
    public class PaginaTiendaModel : PageModel
    {
        private readonly ApiService _apiService;
        public List<Caja> Cajas { get; set; }

        public PaginaTiendaModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            Cajas = await _apiService.GetChestsAsync();
        }
    }
}
