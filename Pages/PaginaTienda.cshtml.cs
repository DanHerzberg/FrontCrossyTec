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
        public Dictionary<long, List<ItemChest>> ItemsPorCaja { get; private set; }
        public int UserCoins { get; private set; }
        private readonly ApiService _apiService;


        public PaginaTiendaModel(ApiService apiService)
        {
            _apiService = apiService;
            ItemsPorCaja = new Dictionary<long, List<ItemChest>>();
        }

        public async Task OnGetAsync()
        {
            try
            {
                // Llama al método GetChestsAsync en ApiService
                cajas = await _apiService.GetChestsAsync();
                UserCoins = await _apiService.GetUserCoinsAsync();
                foreach (var caja in cajas)
                {
                    var items = await _apiService.GetItemChestAsync(caja.ChestId);
                    ItemsPorCaja.Add(caja.ChestId, items);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}