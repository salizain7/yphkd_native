using System;
using Newtonsoft.Json;
using yphkd.Facade;
using yphkd.Model.Game;
using yphkd.Users;

namespace yphkd.Model.ServerResults
{
    public class GameRoundWinnerResult
    {
        [JsonProperty(PropertyName = "result")]
        public int result { get; set; }

        [JsonProperty(PropertyName = "game_table")]
        public GameTable gameTable { get; set; }

        [JsonProperty(PropertyName = "winner_profile")]
        public UsrProfile winnerProfile { get; set; }

        [JsonProperty(PropertyName = "game_round")]
        public GameRound gameRound { get; set; }
    }
}
