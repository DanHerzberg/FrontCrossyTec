using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json; // Si estás utilizando Newtonsoft.Json para la deserialización

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
    }

    public class ChestDto
    {
        public int ChestId { get; set; }
        public string ChestName { get; set; }
        public decimal Price { get; set; }
    }
}
