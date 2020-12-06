using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using yphkd.Model.Game;
using yphkd.Users;

namespace yphkd.Model.ServerResults
{
    public class UserPlayRequestResult 
    {
        [JsonProperty(PropertyName = "result")]
        public int result { get; set; }

        [JsonProperty(PropertyName = "game_table")]
        public GameTable gameTable { get; set; }

        [JsonProperty(PropertyName = "usr_profile_1")]
        public UsrProfile usrProfile_1 { get; set; }

        [JsonProperty(PropertyName = "usr_profile_2")]
        public UsrProfile usrProfile_2 { get; set; }

        [JsonProperty(PropertyName = "usr_profile_3")]
        public UsrProfile usrProfile_3 { get; set; }

        [JsonProperty(PropertyName = "usr_profile_4")]
        public UsrProfile usrProfile_4 { get; set; }

        [JsonProperty(PropertyName = "usr_profile_5")]
        public UsrProfile usrProfile_5 { get; set; }

        
        
    }
}
