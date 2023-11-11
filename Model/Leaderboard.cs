using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FrontCrossyTec.Model
{
    public partial class Leaderboard
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("totalScore")]
        public long TotalScore { get; set; }
    }

    public partial class Leaderboard
    {
        public static List<Leaderboard> FromJson(string json) => JsonConvert.DeserializeObject<List<Leaderboard>>(json, FrontCrossyTec.Model.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Leaderboard> self) => JsonConvert.SerializeObject(self, FrontCrossyTec.Model.Converter.Settings);
    }

    
}

