using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FrontCrossyTec.Model
{
   

    public partial class ItemChest
    {
        [JsonProperty("chest_id")]
        public long ChestId { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }
    }

    public partial class ItemChest
    {
        public static List<ItemChest> FromJson(string json) => JsonConvert.DeserializeObject<List<ItemChest>>(json, FrontCrossyTec.Model.Converter.Settings);
    }

   
   
}
