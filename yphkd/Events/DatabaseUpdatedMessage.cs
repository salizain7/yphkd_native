using System;
namespace yphkd.Events
{
    public class DatabaseUpdatedMessage
    {
        public int MatchID = 0;

        public DatabaseUpdatedMessage()
        {

        }

        public DatabaseUpdatedMessage(int MatchID)
        {
            this.MatchID = MatchID;
        }
    }
}
