using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using yphkd.Model;
using yphkd.ServerApi;
using yphkd.ServerApi.ResponseModel;
using yphkd.Users;
using static yphkd.Utils;

namespace yphkd.Facade
{
    public class UsrManager
    {
        readonly NetworkApi serverManager;
        public static User CurrentUser { get; set; }
        public static NetworkApi sm = new NetworkApi();

        public UsrManager()
        {
            serverManager = new NetworkApi();
            if (CurrentUser == null)
            {
                CurrentUser = User.ReadFromPreferences();
            }
        }

        public async Task<ServerManagerResult> ValidateUsr()
        {
            ServerManagerResult result = new ServerManagerResult();

            if (CurrentUser == null)
            {
                User usr = new User();
                usr.State = -199;
                usr.UserLang = "en";
                CurrentUser = usr;
            }
            if (!String.IsNullOrEmpty(CurrentUser.Guid) && CurrentUser.UserLang != null)
            {
                result = await serverManager.VerifyUser(CurrentUser.Guid, CurrentUser.DeviceId);
            }
            else
            {
                result = await serverManager.VerifyUser(null, "");
            }

            if (result.State < 0)
            {
                if (CurrentUser != null)
                {
                    CurrentUser.DeleteFromPreferences();
                }
            }

            if (CurrentUser.State > 0)
            {
                if (CurrentUser.Guid != null || CurrentUser.Guid != "0") { }
                    //SaveUserDeviceToken(CurrentUser.DeviceToken);
            }
            return result;
        }
        public bool DoShowCompetitionsHomeTutorial()
        {
            if (VersionTracking.IsFirstLaunchEver)
            {
                CurrentUser.SaveToPreferences();
                return true;
            }
            return false;
        }
        public bool DoShowFbConnectEarnPts()
        {
            if (CurrentUser.FBId == null)
            {
                CurrentUser.SaveToPreferences();
                return true;
            }
            return false;
        }
        public async Task<int> CreateSubscriber(string firebaseId)
        {
            var guid = Guid.NewGuid().ToString();
            var deviceId = guid.Replace("-", "");

            ServerManagerResult managerResult = new ServerManagerResult();
            //if (deviceId != null && firebaseId != null)
            //{
            //    managerResult = await serverManager.CreateSubscriber(deviceId, firebaseId);
            //    if (managerResult.http_status == 100 && !String.IsNullOrEmpty(managerResult.user_id))
            //    {
            //        UpdateCurrentUser(managerResult);
            //        SaveDeviceInfo(deviceId);

            //        int getUserPref = UsrManager.CurrentUser.State;
            //        if (getUserPref > 0)
            //            managerResult.State = 100;
            //    }
            //}
            //else
            //{
            //    managerResult.State = -100;
            //}
            return managerResult.State;
        }
        public void SaveDeviceInfo(string deviceId)
        {
            UsrManager.CurrentUser.DeviceId = deviceId;
            var dos = DeviceInfo.Platform;
            if (dos == DevicePlatform.iOS)
                CurrentUser.DeviceOs = 20;
            else
                CurrentUser.DeviceOs = 10;

            CurrentUser.SaveToPreferences();
        }

        public Task<string> DownloadJsonFile(string fileUrl, double secs, bool forceRefresh)
        {
            if (!string.IsNullOrEmpty(fileUrl))
                return serverManager.GetJsonFile(fileUrl, secs, forceRefresh);
            else
                return Task.FromResult("");
        }
        
        

       

        public async Task SavePreferencesToServer(string user)
        {
            if (!string.IsNullOrEmpty(user))
            {
                int managerResult = await serverManager.SavePreferencesToServer(user);
                if (managerResult.Equals(100))
                    UsrManager.CurrentUser.ISSynced = 100;
                else
                    UsrManager.CurrentUser.ISSynced = -100;

                UsrManager.CurrentUser.SaveToPreferences();
            }
        }

       


        public static Hand GetFavoriteHand()
        {
            return CurrentUser.GetFavoriteHand();
        }

        public static Country GetUsrCountry()
        {
            Country rtnValue = null;

            var cntryId = CurrentUser.Profile.UsrCountry;
            if (cntryId == null || cntryId == 0)
            {
                cntryId = 297;
                CurrentUser.Profile.UsrCountry = cntryId;
                CurrentUser.SaveToPreferences();
            }
            if (cntryId != null && cntryId > 0)
            {
                //var countryModel = Country.GetById(cntryId);
                //if (countryModel != null)
                //    rtnValue = countryModel;
            }

            return rtnValue;
        }

        //public static LevelDef GetNextLevel()
        //{
        //    LevelDef rtnValue = null;

        //    var levelNo = CurrentUser.Profile.UsrLevel;
        //    if (levelNo != null && levelNo > 0)
        //    {
        //        var levelModel = LevelDef.GetByLevelNo(levelNo + 1);
        //        if (levelModel != null)
        //            rtnValue = levelModel;
        //    }

        //    return rtnValue;
        //}

        //public void SaveUserDeviceToken(string token)
        //{
        //    if (UsrManager.CurrentUser.Guid != null || UsrManager.CurrentUser.Guid != "0")
        //        sm.SendFCMTokenToServer(token);
        //}

       
        
       
        //public static void GetUsrInfo()
        //{
        //    var response = sm.GetUsrInfo().Result;
        //    if (!string.IsNullOrEmpty(response))
        //    {
        //        try
        //        {
        //            JObject jObj = new JObject();
        //            jObj = JObject.Parse(response);
        //            if (jObj.ContainsKey("usr_profile"))
        //            {
        //                UsrProfile usrProfile = JsonConvert.DeserializeObject<UsrProfile>(jObj.GetValue("usr_profile").ToString());
        //                CurrentUser.Profile = usrProfile;
        //            }
        //            if (jObj.ContainsKey("usr_group"))
        //            {
        //                List<UsrGroup> usrGroupList = JsonConvert.DeserializeObject<List<UsrGroup>>(jObj.GetValue("usr_group").ToString());
        //                CurrentUser.UsrGroupList = usrGroupList;
        //            }
        //            if (jObj.ContainsKey("usr_content"))
        //            {
        //                List<UsrContent> usrContentList = JsonConvert.DeserializeObject<List<UsrContent>>(jObj.GetValue("usr_content").ToString());
        //                CurrentUser.UserContentList = usrContentList;
        //            }
        //            if (jObj.ContainsKey("usr_friends"))
        //            {
        //                List<UsrProfile> usrFriendList = JsonConvert.DeserializeObject<List<UsrProfile>>(jObj.GetValue("usr_friends").ToString());
        //                CurrentUser.UsrFriendList = usrFriendList;
        //            }
        //            if (jObj.ContainsKey("usr_status"))
        //            {
        //                int usrSts = JsonConvert.DeserializeObject<int>(jObj.GetValue("usr_status").ToString());
        //                CurrentUser.State = usrSts;
        //            }
        //            if (jObj.ContainsKey("device_os"))
        //            {
        //                int deviceOs = JsonConvert.DeserializeObject<int>(jObj.GetValue("device_os").ToString());
        //                CurrentUser.DeviceOs = deviceOs;
        //            }
        //            if (jObj.ContainsKey("device_id"))
        //            {
        //                var deviceId = jObj.GetValue("device_id").ToString();
        //                CurrentUser.DeviceId = deviceId;
        //            }
        //            if (jObj.ContainsKey("join_dt"))
        //            {
        //                var regDt = jObj.GetValue("join_dt").ToString();
        //                CurrentUser.RegistrationDate = regDt;
        //            }
        //            if (jObj.ContainsKey("device_token"))
        //            {
        //                string dToken = jObj.GetValue("device_token").ToString();
        //                CurrentUser.DeviceToken = dToken;
        //                CurrentUser.FBToken = dToken;
        //            }
        //            if (jObj.ContainsKey("usr_reported_msg"))
        //            {
        //                List<UsrReportedMsg> usrReportedMsgsList = JsonConvert.DeserializeObject<List<UsrReportedMsg>>(jObj.GetValue("usr_reported_msg").ToString());
        //                CurrentUser.UsrReportedMessageList = usrReportedMsgsList;
        //            }
        //            if (jObj.ContainsKey("usr_poll"))
        //            {
        //                List<UsrPoll> usrPollList = JsonConvert.DeserializeObject<List<UsrPoll>>(jObj.GetValue("usr_poll").ToString());
        //                CurrentUser.UsrPollsList = usrPollList;
        //            }
        //            if (jObj.ContainsKey("lang"))
        //            {
        //                int value = int.Parse(jObj.GetValue("lang").ToString());
        //                if (value != 0)
        //                {
        //                    if (value == (int)AppLang.EN)
        //                        UsrManager.CurrentUser.UserLang = "en";
        //                    else if (value == (int)AppLang.AR)
        //                        UsrManager.CurrentUser.UserLang = "ar";
        //                    else if (value == (int)AppLang.SP)
        //                        UsrManager.CurrentUser.UserLang = "sp";
        //                    else
        //                        UsrManager.CurrentUser.UserLang = "en";
        //                }
        //            }
        //            CurrentUser.SaveToPreferences();
        //            CurrentUser = User.ReadFromPreferences();
        //        }

        //        catch (Exception ex)
        //        {
        //            TrackErrors(MethodBase.GetCurrentMethod(), ex);
        //            Debug.WriteLine(ex.StackTrace);
        //        }
        //    }

        //}

        //public static void GetUsrInfoByFbId()
        //{
        //    var response = sm.GetUsrInfoByFbId().Result;
        //    if (!string.IsNullOrEmpty(response))
        //    {
        //        try
        //        {
        //            JObject jObj = new JObject();
        //            jObj = JObject.Parse(response);
        //            if (jObj.ContainsKey("usr_profile"))
        //            {
        //                UsrProfile usrProfile = JsonConvert.DeserializeObject<UsrProfile>(jObj.GetValue("usr_profile").ToString());
        //                CurrentUser.Profile = usrProfile;
        //            }
        //            if (jObj.ContainsKey("usr_group"))
        //            {
        //                List<UsrGroup> usrGroupList = JsonConvert.DeserializeObject<List<UsrGroup>>(jObj.GetValue("usr_group").ToString());
        //                CurrentUser.UsrGroupList = usrGroupList;
        //            }
        //            if (jObj.ContainsKey("usr_content"))
        //            {
        //                List<UsrContent> usrContentList = JsonConvert.DeserializeObject<List<UsrContent>>(jObj.GetValue("usr_content").ToString());
        //                CurrentUser.UserContentList = usrContentList;
        //            }
        //            if (jObj.ContainsKey("usr_friends"))
        //            {
        //                List<UsrProfile> usrFriendList = JsonConvert.DeserializeObject<List<UsrProfile>>(jObj.GetValue("usr_friends").ToString());
        //                CurrentUser.UsrFriendList = usrFriendList;
        //            }
        //            if (jObj.ContainsKey("usr_status"))
        //            {
        //                int usrSts = JsonConvert.DeserializeObject<int>(jObj.GetValue("usr_status").ToString());
        //                CurrentUser.State = usrSts;
        //            }
        //            if (jObj.ContainsKey("device_os"))
        //            {
        //                int deviceOs = JsonConvert.DeserializeObject<int>(jObj.GetValue("device_os").ToString());
        //                CurrentUser.DeviceOs = deviceOs;
        //            }
        //            if (jObj.ContainsKey("device_id"))
        //            {
        //                var deviceId = jObj.GetValue("device_id").ToString();
        //                CurrentUser.DeviceId = deviceId;
        //            }
        //            if (jObj.ContainsKey("join_dt"))
        //            {
        //                var regDt = jObj.GetValue("join_dt").ToString();
        //                CurrentUser.RegistrationDate = regDt;
        //            }
        //            if (jObj.ContainsKey("device_token"))
        //            {
        //                string dToken = jObj.GetValue("device_token").ToString();
        //                CurrentUser.DeviceToken = dToken;
        //                CurrentUser.FBToken = dToken;
        //            }
        //            if (jObj.ContainsKey("usr_reported_msg"))
        //            {
        //                List<UsrReportedMsg> usrReportedMsgsList = JsonConvert.DeserializeObject<List<UsrReportedMsg>>(jObj.GetValue("usr_reported_msg").ToString());
        //                CurrentUser.UsrReportedMessageList = usrReportedMsgsList;
        //            }
        //            if (jObj.ContainsKey("usr_poll"))
        //            {
        //                List<UsrPoll> usrPollList = JsonConvert.DeserializeObject<List<UsrPoll>>(jObj.GetValue("usr_poll").ToString());
        //                CurrentUser.UsrPollsList = usrPollList;
        //            }
        //            if (jObj.ContainsKey("lang"))
        //            {
        //                int value = int.Parse(jObj.GetValue("lang").ToString());
        //                if (value != 0)
        //                {
        //                    if (value == (int)AppLang.EN)
        //                        UsrManager.CurrentUser.UserLang = "en";
        //                    else if (value == (int)AppLang.AR)
        //                        UsrManager.CurrentUser.UserLang = "ar";
        //                    else if (value == (int)AppLang.SP)
        //                        UsrManager.CurrentUser.UserLang = "sp";
        //                    else
        //                        UsrManager.CurrentUser.UserLang = "en";
        //                }
        //            }
        //            CurrentUser.SaveToPreferences();
        //            CurrentUser = User.ReadFromPreferences();
        //        }

        //        catch (Exception ex)
        //        {
        //            TrackErrors(MethodBase.GetCurrentMethod(), ex);
        //            Debug.WriteLine(ex.StackTrace);
        //        }
        //    }

        //}

        

       
    }
}
