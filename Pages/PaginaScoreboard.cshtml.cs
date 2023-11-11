using System.Collections.Generic;
using System.Threading.Tasks;
using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontCrossyTec.Pages
{
    public class PaginaScoreboardModel : PageModel
    {
        private readonly ApiService _apiService;

        public PaginaScoreboardModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Leaderboard> LeaderboardData { get; set; }

        public async Task OnGetAsync()
        {
            LeaderboardData = await _apiService.GetLeaderboardAsync();
        }
    }
}

