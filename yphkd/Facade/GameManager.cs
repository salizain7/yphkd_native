using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using yphkd.Model.ServerResults;
using yphkd.ServerApi;

namespace yphkd.Facade
{
    public class GameManager
    {
        private static UsrManager manager = new UsrManager();
        private static NetworkApi sm = new NetworkApi();

        public GameManager()
        {
        }
       
        public async  Task<UserPlayRequestResult> UserPlayRequest(int tableType)
        {
            UserPlayRequestResult uprResult = null;
            try
            {
                var response = await sm.UserPlayRequest(tableType);
                uprResult = JsonConvert.DeserializeObject<UserPlayRequestResult>(response);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception : " +  e.StackTrace);
            }
            return uprResult;

        }

        public async Task<GameRoundWinnerResult> GetWinner(int roundNo, int gameTableId, int symbolSelected)
        {
            GameRoundWinnerResult rwResult = null;
            try
            {
                var response = await sm.GetWinner(roundNo, gameTableId, symbolSelected);
                rwResult = JsonConvert.DeserializeObject<GameRoundWinnerResult>(response);
            }            
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.StackTrace);
            }
            return rwResult;

        }
    }
}
