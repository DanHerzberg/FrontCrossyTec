using System.Collections.Generic;
using System.Threading.Tasks;
using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> OnPostComprarCajaAsync(int price)
        {
            UserCoins = await _apiService.GetUserCoinsAsync();
            if (UserCoins >= price)
            {
                int newCoinTotal = UserCoins - price;

                // Aquí llamarías a ApiService para actualizar la cantidad de monedas en la base de datos
                var exito = await _apiService.ActualizarMonedasUsuarioAsync(newCoinTotal);
                if (exito)
                {
                    // Actualizar la interfaz de usuario o recargar la página
                    return RedirectToPage(new { compraExitosa = true });
                }
                else
                {
                    // Manejar el caso de error
                    return RedirectToPage(new { error = "Error al actualizar las monedas." });
                }
            }
            else
            {
                // Manejar el caso de saldo insuficiente
                return RedirectToPage(new { error = "Saldo insuficienteeeee." });
            }
        }


    }
}