using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace FrontCrossyTec.Model
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
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
                // Maneja la excepción aquí
                return null;
            }
        }



        public async Task<HttpResponseMessage> RegisterAsync(RegistroUsuario registroUsuario)
        {
            try
            {
                string jsonRegistro = JsonConvert.SerializeObject(registroUsuario);
                var content = new StringContent(jsonRegistro, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/RegisterUser", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RegistroUsuarioResponse>(jsonResponse);

                    // Guardar los datos del usuario en la sesión
                    _httpContextAccessor.HttpContext.Session.SetString("UserId", result.UserId.ToString());
                    _httpContextAccessor.HttpContext.Session.SetString("UserName", result.Name);
                    // ... agrega más datos según tus necesidades
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public async Task<HttpResponseMessage> LoginAsync(string email, string password)
        {
            var loginInfo = new { Email = email, Password = password };
            string jsonLogin = JsonConvert.SerializeObject(loginInfo);
            var content = new StringContent(jsonLogin, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Login", content);

            return response;
        }
    }

    // Resto de las clases como ChestDto, Login, RegistroUsuario, etc.
}





public class Login
{
    public string email { get; set; }
    public string password { get; set; }

}

public class RegistroUsuario
{
    public string name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string gamertag { get; set; }
    public string password { get; set; }
    public DateTime birth_date { get; set; }
    public string gender { get; set; }
    public string state { get; set; }
    public int coins { get; set; } = 0;
    public string rol { get; set; } = "Player";
}

