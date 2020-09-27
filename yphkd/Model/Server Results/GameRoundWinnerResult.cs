using System;
using yphkd.Facade;
using yphkd.Users;

namespace yphkd.Model.ServerResults
{
    public class GameRoundWinnerResult
    {
        private UsrProfile Up;
        public UsrProfile UsrProfile
        {
            get
            {
                return Up;
            }
            set
            {
                // Up = value;
                UsrManager.CurrentUser.Profile = value;
                UsrManager.CurrentUser.SaveToPreferences();
            }
        }

    }
}
