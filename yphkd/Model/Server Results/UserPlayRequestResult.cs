using System;
using Newtonsoft.Json;
using yphkd.Model.Game;

namespace yphkd.Model.ServerResults
{
    public class UserPlayRequestResult 
    {
        [JsonProperty(PropertyName = "result")]
        public int result { get; set; }

        [JsonProperty(PropertyName = "game_table")]
        public GameTable gameTable { get; set; }
    }
}
