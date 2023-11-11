using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json; // Si estás utilizando Newtonsoft.Json para la deserialización
using System.Text;

namespace FrontCrossyTec.Model
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Caja>> GetChestsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Chest");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var chests = JsonConvert.DeserializeObject<List<ChestDto>>(json); // Utiliza una clase DTO si la estructura difiere de tu modelo Caja

                    var cajas = new List<Caja>();
                    foreach (var chest in chests)
                    {
                        cajas.Add(new Caja
                        {
                            Id = chest.ChestId,
                            Nombre = chest.ChestName,
                            Precio = chest.Price
                        });
                    }

                    return cajas;
                }

                // Maneja la respuesta fallida aquí, si es necesario
                return null;
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

            return response;
        }
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

    public class ChestDto
    {
        public int ChestId { get; set; }
        public string ChestName { get; set; }
        public decimal Price { get; set; }
    }

    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }

    }

}
