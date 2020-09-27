using System;
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

    }
}
