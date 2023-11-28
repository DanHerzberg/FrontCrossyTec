using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontCrossyTec.Pages
{
    public class PaginaAdminModel : PageModel
    {
        private readonly ApiService _apiService;

        public PaginaAdminModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<UserCountByStateDto> UserCountsByState { get; private set; }
        public List<UserAgeDto> UserCountsByAge { get; private set; }
        public List<UserGenderDto> UserCountsByGender { get; private set; }
        public List<CoinsStateDto> CoinsByState { get; private set; }

        public async Task OnGetAsync()
        {
            UserCountsByState = await _apiService.GetUserCountsByStateAsync();
            UserCountsByAge = await _apiService.GetUserAgesAsync();
            UserCountsByGender = await _apiService.GetUserGendersAsync();
            CoinsByState = await _apiService.GetCoinsByStateAsync();


        }
    }
}