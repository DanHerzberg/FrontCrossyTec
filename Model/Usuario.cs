using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;

namespace FrontCrossyTec.Model
{
    public partial class Usuario
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
        public Gender Gender { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("rol")]
        public Rol Rol { get; set; }
    }

    public enum Gender { Femenino, Hombre, Masculino };

    public enum Rol { Admin, Player, RolPlayer };

    public partial class Usuario
    {
        public static List<Usuario> FromJson(string json) => JsonConvert.DeserializeObject<List<Usuario>>(json, FrontCrossyTec.Model.Converter.Settings);
    }


    internal class GenderConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Gender) || t == typeof(Gender?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Femenino":
                    return Gender.Femenino;
                case "Masculino":
                    return Gender.Masculino;
                case "hombre":
                    return Gender.Hombre;
            }
            throw new Exception("Cannot unmarshal type Gender");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Gender)untypedValue;
            switch (value)
            {
                case Gender.Femenino:
                    serializer.Serialize(writer, "Femenino");
                    return;
                case Gender.Masculino:
                    serializer.Serialize(writer, "Masculino");
                    return;
                case Gender.Hombre:
                    serializer.Serialize(writer, "hombre");
                    return;
            }
            throw new Exception("Cannot marshal type Gender");
        }

        public static readonly GenderConverter Singleton = new GenderConverter();
    }

    internal class RolConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Rol) || t == typeof(Rol?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Player":
                    return Rol.RolPlayer;
                case "admin":
                    return Rol.Admin;
                case "player":
                    return Rol.Player;
            }
            throw new Exception("Cannot unmarshal type Rol");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Rol)untypedValue;
            switch (value)
            {
                case Rol.RolPlayer:
                    serializer.Serialize(writer, "Player");
                    return;
                case Rol.Admin:
                    serializer.Serialize(writer, "admin");
                    return;
                case Rol.Player:
                    serializer.Serialize(writer, "player");
                    return;
            }
            throw new Exception("Cannot marshal type Rol");
        }

        public static readonly RolConverter Singleton = new RolConverter();
    }
}
