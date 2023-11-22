using System.Collections.Generic;
using System.Threading.Tasks;
using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace FrontCrossyTec.Pages
{
    public class PaginaTiendaModel : PageModel
    {
        public List<Chest> cajas { get; private set; }
        public int UserCoins { get; private set; }

        public async Task OnGetAsync()
        {
            var apiService = new ApiService(new HttpClient(), new HttpContextAccessor());

            try
            {
                cajas = await apiService.GetChestsAsync();
                UserCoins = await apiService.GetUserCoinsAsync();
            }
            catch (Exception ex)
            {
                throw ex;
              
            }
        }
    }
}