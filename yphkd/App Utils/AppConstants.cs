using System;
using System.Collections.Generic;

namespace yphkd.AppUtils
{
    public class AppConstants
    {
        public AppConstants()
        {
        }

        public static string BASE_URL_LOGIN_API = "http://35.229.202.243:51301/"; //sql8 
        public static string BASE_URL = "http://wphub.earthfactor.net/paymentgateway/public/api/";
        public static string AppVersion = "55";

        public static string Game_URL = "http://35.229.202.243:51301/"; //sql8 
        public static string Token = "";
    }
    public static class Validation<T>
    {
        public static bool ValidateList(List<T> ts)
        {
            if (ts != null)
            {
                if (ts.Count > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}