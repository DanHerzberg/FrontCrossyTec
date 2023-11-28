using System.Collections.Generic;
using System.Threading.Tasks;
using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontCrossyTec.Pages
{
    public class PaginaTiendaModel : PageModel
    {
        public List<Chest> cajas { get; private set; }
        public int UserCoins { get; private set; }
        private readonly ApiService _apiService;

        public PaginaTiendaModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            try
            {
                // Llama al método GetChestsAsync en ApiService
                cajas = await _apiService.GetChestsAsync();
                UserCoins = await _apiService.GetUserCoinsAsync();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}