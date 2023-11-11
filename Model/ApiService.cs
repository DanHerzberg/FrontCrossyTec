using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FrontCrossyTec.Model
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para obtener datos de Chest
        public async Task<List<Chest>> GetChestsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7173/api/Chest");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Chest>>(content, Converter.Settings);
                }
                else
                {
                    // Aquí puedes manejar errores, lanzar excepciones, etc.
                    throw new Exception($"Error al obtener datos: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar excepciones de red u otras excepciones que puedan ocurrir
                throw new Exception($"Error en la solicitud HTTP: {ex.Message}");
            }
        }

        // Método para obtener datos de Leaderboard y guardarlos en una lista
        public async Task<List<Leaderboard>> GetLeaderboardAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7173/api/Leaderboard");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Leaderboard>>(content, Converter.Settings);
                }
                else
                {
                    // Aquí puedes manejar errores, lanzar excepciones, etc.
                    throw new Exception($"Error al obtener datos de Leaderboard: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar excepciones de red u otras excepciones que puedan ocurrir
                throw new Exception($"Error en la solicitud HTTP: {ex.Message}");
            }
        }
    }
}
