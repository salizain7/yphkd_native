using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using yphkd.Model;

namespace yphkd.Users
{
    public class UsrContent
    {
        public UsrContent()
        {
        }
        public UsrContent(int ContentId, int ContentType)
        {
            this.ContentId = ContentId;
            this.ContentType = ContentType;
        }

        [JsonProperty(PropertyName = "user_id")]
        public string UsrId { get; set; }
        [JsonProperty(PropertyName = "content_type")]
        public int ContentType { get; set; }
        [JsonProperty(PropertyName = "content_id")]
        public int ContentId { get; set; }
        [JsonProperty(PropertyName = "is_fav")]
        public int IsFav { get; set; } = -100;

        
       
        public async Task<Hand> GetHand()
        {
            Hand playerHand = new Hand();
            //playerHand = Hand.GetById(ContentId);
            //if (playerHand != null)
            //{
            //    playerHand.IsFavourite = IsFav == 200;
            //}

            return playerHand;
        }

        

        public void SetAsFavorite()
        {
            if (IsFav != 200)
                IsFav = 200;
        }

        public void RemoveFromFavorite()
        {
            IsFav = -100;
        }
        
    }
}
