using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FrontCrossyTec.Model
{
    public partial class RegistroUsuarioResponse
    {
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("birth_date")]
        public DateTimeOffset BirthDate { get; set; }

        [JsonProperty("gamertag")]
        public string Gamertag { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("coins")]
        public long Coins { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("rol")]
        public string Rol { get; set; }

        public static List<RegistroUsuarioResponse> FromJson(string json) => JsonConvert.DeserializeObject<List<RegistroUsuarioResponse>>(json, Converter.Settings);
    }

    
}
