using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using yphkd.Model;
using yphkd.Model.GameDefinition;

namespace yphkd.Users
{
    public class UsrContent
    {
        public UsrContent()
        {
        }
        public UsrContent(int ContentId)
        {
            this.ContentId = ContentId;
        }

        [JsonProperty(PropertyName = "user_id")]
        public string UsrId { get; set; }
        [JsonProperty(PropertyName = "content_id")]
        public int ContentId { get; set; }
        [JsonProperty(PropertyName = "is_fav")]
        public int IsFav { get; set; } = -100;

        
       
        public async Task<Hand> GetHand()
        {
            Hand playerHand = new Hand();
            playerHand.Id = ContentId;
            playerHand.Title = Enum.GetName(typeof(GameEnums.HandEnum), ContentId);
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
