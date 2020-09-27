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
        //public static UsrGameStatusByWeekResult GetGameStatusByWeek(string weekNo)
        //{
        //    UsrGameStatusByWeekResult UsrGameStatusResultObj = null;
        //    var response = sm.GetGameStatusByWeek(weekNo).Result; //GetGameStatus by weekId

        //    if (!string.IsNullOrEmpty(response))
        //    {

        //        UsrGameStatusResultObj = JsonConvert.DeserializeObject<UsrGameStatusByWeekResult>(response);

        //    }
        //    return UsrGameStatusResultObj;
        //}
        public async  Task<UserPlayRequestResult> UserPlayRequestAsync(int tableType)
        {
            UserPlayRequestResult uprResult = null;
            var response = await sm.UserPlayRequest(tableType);
            uprResult = JsonConvert.DeserializeObject<UserPlayRequestResult>(response);
            return uprResult;

        }

    }
}
