using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FrontCrossyTec.Model
{
    public class Chest
    {
        public Chest()
        {
        }

        [JsonProperty("chest_id")]
        public long ChestId { get; set; }

        [JsonProperty("chest_name")]
        public string ChestName { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        public static List<Chest> FromJson(string json)
        {
            return JsonConvert.DeserializeObject<List<Chest>>(json, Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Converter.Settings);
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
