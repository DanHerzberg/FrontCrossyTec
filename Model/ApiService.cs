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
                var response = await _httpClient.GetAsync("/api/Chest");
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
                var response = await _httpClient.GetAsync("/api/Leaderboard");

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

            if (response.IsSuccessStatusCode)
            {
                var userEmail = email;
                _httpContextAccessor.HttpContext.Response.Cookies.Append("UserEmail", userEmail);
            }

            return response;
        }

        public async Task<int> GetUserCoinsAsync()
        {
            try
            {
                var email = _httpContextAccessor.HttpContext.Request.Cookies["UserEmail"];
                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("No se encontró el correo electrónico del usuario en las cookies.");
                }

                var response = await _httpClient.GetAsync($"/api/GetUserCoins?email={email}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<int>(content);
                }
                else
                {
                    throw new Exception($"Error al obtener monedas: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la solicitud HTTP: {ex.Message}");
            }
        }


        public async Task<User> GetUserInfoAsync()
        {
    try
    {
        var email = _httpContextAccessor.HttpContext.Request.Cookies["UserEmail"]; 
        if (string.IsNullOrEmpty(email))
        {
            throw new Exception("No se encontró el correo electrónico del usuario en las cookies.");
        }

        var response = await _httpClient.GetAsync($"/api/User?email={email}");
        if (response.IsSuccessStatusCode)
        {
                    var content = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<User>>(content);
                    return users.FirstOrDefault(); // Retorna el primer usuario o null si no hay ninguno
                }
        else
        {
            throw new Exception($"Error al obtener la información del usuario: {response.StatusCode}");
        }
    }
    catch (Exception ex)
    {
        throw new Exception($"Error en la solicitud HTTP: {ex.Message}");
    }
}

        public async Task<List<UserCountByStateDto>> GetUserCountsByStateAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7173/api/UserCountsByState");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<UserCountByStateDto>>(content);
                }
                else
                {
                    throw new Exception($"Error al obtener el conteo de usuarios por estado: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la solicitud HTTP: {ex.Message}");
            }
        }


        public async Task<List<UserAgeDto>> GetUserAgesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/UserAges");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<UserAgeDto>>(content);
                }
                else
                {
                    throw new Exception($"Error al obtener el conteo de usuarios por edad: {response.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la solicitud HTTP: {ex.Message}");
            }
        }


        public async Task<List<ItemChest>> GetItemChestAsync(long id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/OptionsItems/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ItemChest>>(content);
                }
                else
                {
                    throw new Exception($"Error al obtener el objeto ItemChest: {response.StatusCode}");
                }

        public async Task<List<UserGenderDto>> GetUserGendersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/UserGenders");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<UserGenderDto>>(content);
                }
                else
                {
                    throw new Exception($"Error al obtener el conteo de usuarios por genero: {response.StatusCode}");
                }


            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la solicitud HTTP: {ex.Message}");
            }
        }

    


        public async Task<List<CoinsStateDto>> GetCoinsByStateAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/CoinsByState");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<CoinsStateDto>>(content);
                }
                else
                {
                    throw new Exception($"Error al obtener el conteo de monedas por estado: {response.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la solicitud HTTP: {ex.Message}");
            }
        }





}

    // Resto de las clases como ChestDto, Login, RegistroUsuario, etc.
}


public class LoginResponseDto
{
    public string Email { get; set; }
    public string Message { get; set; }
    public string Rol { get; set; }
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

public class UserCountByStateDto
{
    public string State { get; set; }
    public int UserCount { get; set; }
}

public class UserAgeDto
{
    public int Age { get; set; }
    public int UserCount { get; set; }
}

public class UserGenderDto
{
    public string Gender { get; set; }
    public int UserCount { get; set; }
}

public class CoinsStateDto
{
    public string State { get; set; }
    public int TotalCoins { get; set; }
}


