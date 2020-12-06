using System;
using Newtonsoft.Json;

namespace yphkd.Users
{
    public class UsrProfile
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "usr_id")]
        public string Guid { get; set; }

        [JsonProperty(PropertyName = "usr_name")]
        public string UsrName { get; set; }

        [JsonProperty(PropertyName = "usr_img")]
        public string UsrImg { get; set; }

        [JsonProperty(PropertyName = "usr_xp_pts")]
        public int UsrXPPts { get; set; }

        [JsonProperty(PropertyName = "usr_coins")]
        public int UsrCoins { get; set; }

        [JsonProperty(PropertyName = "usr_lang")]
        public string UsrLang { get; set; }

        [JsonProperty(PropertyName = "facebook_id")]
        public string FacebookId { get; set; }

        [JsonProperty(PropertyName = "usr_level")]
        public int UsrLevel { get; set; }

        [JsonProperty(PropertyName = "usr_country")]
        public int UsrCountry { get; set; }

        [JsonProperty(PropertyName = "usr_gender")]
        public int UsrGender { get; set; }

        [JsonProperty(PropertyName = "usr_symbol")]
        public string UsrSymbol{ get; set; }

        
    }
}
