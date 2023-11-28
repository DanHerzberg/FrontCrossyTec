using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FrontCrossyTec.Model
{
    public class User
    {
        public User()
        {
        }

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
        public Gender Gender { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("rol")]
        public Rol Rol { get; set; }


        public static List<User> FromJson(string json) => JsonConvert.DeserializeObject<List<User>>(json, Converter.Settings);

       
    }

    public static class UserExtensions
    {
        public static string ToJson(this List<User> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public enum Gender { Femenino, Hombre, Masculino };

    public enum Rol { Admin, Player, RolPlayer };


}
