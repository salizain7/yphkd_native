using System;
using Newtonsoft.Json;

namespace yphkd.ServerApi.ResponseModel
{
    public class ServerManagerResult
    {
        [JsonProperty(PropertyName = "result")]
        public int State { get; set; }

        [JsonProperty(PropertyName = "http_status")]
        public int http_status { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string user_id { get; set; }
        public ServerManagerResult()
        {
            
        }
    }
}
