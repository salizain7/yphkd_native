using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AppCenter.Crashes;
using yphkd.Db;
using yphkd.Facade;

namespace yphkd
{
    public class Utils
    {
        public Utils()
        {
        }
        public static void TrackErrors(MethodBase mb, Exception ex)
        {
            var prop = new Dictionary<string, string>
             {
                {"Method Name Tag" , mb?.Name},
                {"Reflected Method Name" ,mb?.Name},
                {"Calling Method Name Path" ,mb?.DeclaringType?.ToString()},
                {"Reflected Method Name Path" , mb?.ToString()},
                {"TargetSite Method Name", ex?.StackTrace},
                {"Current UserId", UsrManager.CurrentUser?.Guid },
                {"Current User Favorite Hand", UsrManager.CurrentUser?.GetFavoriteHand()?.Title },
                {"Current User Favorite HandId", UsrManager.CurrentUser?.GetFavoriteHand()?.Id.ToString()},
                {"Current User App Lang", UsrManager.CurrentUser?.UserLang}
             };
            //Crashes.TrackError(ex, prop);
        }
        public class Country : CountryTable
        {
            public string GetTitle()
            {
                return Title;
            }
        }
    }
    
}
