using System;
using System.Net.Http;
using System.Threading.Tasks;
using yphkd.ServerApi.Interface;
using yphkd.ServerApi.ResponseModel;
using yphkd.Users;
using yphkd.Facade;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace yphkd.ServerApi
{
    public class NetworkApi 
    {
        HttpClient httpClient;

        public NetworkApi()
        {
            httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
        }

        public Task<string> GetGameSeasonStanding(int seasonId)
        {
            return Task.Run(async () =>
            {
                if (UsrManager.CurrentUser.Profile.UsrCountry == null || UsrManager.CurrentUser.Profile.UsrCountry == 0)
                {
                    UsrManager.CurrentUser.Profile.UsrCountry = 297;
                }
                string result = null;
                var uri = new Uri(string.Format(AppConstants.Game_URL + "getGameSeasonStanding?usr_id=" + UsrManager.CurrentUser.Guid + "&season_id=" + seasonId + "&country_id=" + UsrManager.CurrentUser.Profile.UsrCountry));
                try
                {
                    var response = httpClient.GetAsync(uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var asyncRes = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(asyncRes))
                            result = asyncRes;
                    }
                }
                catch (Exception ex)
                {
                    Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);
                    Debug.WriteLine(ex.StackTrace);
                }

                return result;
            });
        }

        public Task<ServerManagerResult> CreateSubscriber(string deviceId, string firebaseId)
        {
            return Task.Run(async () =>
            {

                ServerManagerResult managerResult = new ServerManagerResult();
                //var uri = new Uri(string.Format(AppConstants.BASE_URL_LOGIN_API + "createUser?device_id=" + deviceId + "&firebase_id=" + firebaseId));
                //try
                //{
                //    var response = httpClient.GetAsync(uri).Result;
                //    if (response.IsSuccessStatusCode)
                //    {
                //        var asyncRes = await response.Content.ReadAsStringAsync();
                //        if (!string.IsNullOrEmpty(asyncRes))
                //            managerResult = JsonConvert.DeserializeObject<ServerManagerResult>(asyncRes);
                //        else
                //            managerResult.State = -100;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Utils.TrackErrors(MethodBase., ex);
                //    Debug.WriteLine(ex.StackTrace);
                //}
                return managerResult;
            });

        }

        public Task<string> GetJsonFile(string url, double secs, bool forceRefresh)
        {
            return Task.Run(() =>
            {
                //string fetchUrl = AppConstants.BASE_URL + url;

                //if (Barrel.Current.Exists(fetchUrl) == true && Barrel.Current.IsExpired(fetchUrl) == false && forceRefresh == false)
                //{
                //    return Barrel.Current.Get<string>(fetchUrl);
                //}

                string responseStr = "";
                //var uri = new Uri(string.Format(fetchUrl));
                //try
                //{
                //    Console.WriteLine(DateTime.Now);
                //    var response = httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead).Result;
                //    Console.WriteLine(DateTime.Now);
                //    if (response.IsSuccessStatusCode)
                //    {
                //        if (fetchUrl.Contains(".zip"))
                //        {
                //            Console.WriteLine(DateTime.Now);
                //            responseStr = Unzip(response.Content.ReadAsByteArrayAsync().Result);
                //            Console.WriteLine(DateTime.Now);
                //        }
                //        else
                //        {
                //            responseStr = response.Content.ReadAsStringAsync().Result;
                //        }

                //        JObject jObject = JObject.Parse(responseStr);
                //        double ExpirySeconds = secs;

                //        if (jObject.ContainsKey("cache_expiry_dt"))
                //        {
                //            var valuedt = jObject["cache_expiry_dt"].ToString();
                //            if (!string.IsNullOrEmpty(valuedt))
                //            {
                //                DateTime expiryDateUtc = DateTime.Parse(valuedt).ToLocalTime();
                //                if (expiryDateUtc > DateTime.Now.ToLocalTime())
                //                {
                //                    var durationExpiry = expiryDateUtc - DateTime.Now.ToLocalTime();
                //                    ExpirySeconds = durationExpiry.TotalSeconds;
                //                }
                //                else
                //                {
                //                    secs = 1;
                //                }

                //            }
                //        }
                //        Barrel.Current.Add(fetchUrl, responseStr, TimeSpan.FromSeconds(ExpirySeconds));
                //    }

                //}
                //catch (Exception ex)
                //{
                //    Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);
                //    Debug.WriteLine("Error --> " + ex.StackTrace);
                //}


                return responseStr;
            });
        }
        
       

        public Task<ServerManagerResult> VerifyUser(string id, string deviceId)
        {
            return Task.Run(async () =>
            {
                ServerManagerResult managerResult = new ServerManagerResult();

                //Uri uri = new Uri(string.Format(AppConstants.BASE_URL_LOGIN_API + "verifyUser?usr_id=" + id + "&device_id=" + deviceId));

                //try
                //{
                //    var response = httpClient.GetAsync(uri).Result;
                //    if (response.IsSuccessStatusCode)
                //    {
                //        var asyncRes = await response.Content.ReadAsStringAsync();
                //        if (!string.IsNullOrEmpty(asyncRes))
                //            managerResult = JsonConvert.DeserializeObject<ServerManagerResult>(asyncRes);
                //        else
                //            managerResult.State = -100;

                //    }
                //}
                //catch (Exception ex)
                //{
                //    Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);
                //    Debug.WriteLine(ex.StackTrace);
                //}
                return managerResult;
            });
        }

        public Task<int> SavePreferencesToServer(string user)
        {
            return Task.Run(async () =>
            {
                ServerManagerResult managerResult = new ServerManagerResult();
                managerResult.State = -100;
                //var stringVal = AppConstants.BASE_URL_LOGIN_API + "saveUserPreference?jsonParameter={0}";

                //try
                //{
                //    using (var client = new HttpClient())
                //    {
                //        client.BaseAddress = new Uri(String.Format(stringVal, user));
                //        var request = await client.PostAsync(client.BaseAddress, null);
                //        var response = await request.Content.ReadAsStringAsync();
                //        if (request.IsSuccessStatusCode)
                //        {
                //            managerResult.State = 100;
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);
                //    Debug.WriteLine(ex.Message);
                //}

                return managerResult.State;
            });
        }

       
        public void GetUserPreferences(int user_id)
        {
            //Task.Run(async () =>
            //{
            if (UsrManager.CurrentUser == null)
            {
                UsrManager.CurrentUser = new User();
            }

            //var stringVal = AppConstants.BASE_URL_LOGIN_API + "/getUserPreference?userId=" + user_id;
            //var uri = new Uri(stringVal);
            //try
            //{
            //    var response = httpClient.GetAsync(uri).Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var asyncRes = response.Content.ReadAsStringAsync().Result;
            //        if (!string.IsNullOrEmpty(asyncRes))
            //        {
            //            List<UsrContent> ContentList = new List<UsrContent>();
            //            JObject jObject = JObject.Parse(asyncRes);
            //            foreach (JProperty property in jObject.Properties())
            //            {
            //                if (property.Name.Equals("id"))
            //                {
            //                    string value = property.Value.ToString();
            //                    if (!string.IsNullOrEmpty(value))
            //                        UsrManager.CurrentUser.Guid = value;
            //                }

            //                if (property.Name.Equals("state"))
            //                {
            //                    string value = property.Value.ToString();
            //                    if (!string.IsNullOrEmpty(value))
            //                        UsrManager.CurrentUser.State = int.Parse(property.Value.ToString());
            //                }
            //                if (property.Name.Equals("lang"))
            //                {
            //                    int value = int.Parse(property.Value.ToString());
            //                    if (value != 0)
            //                    {
            //                        UsrManager.CurrentUser.UserLang = "en";
            //                    }
            //                }
            //                if (property.Name.Equals("UserContentList"))
            //                {
            //                    string value = property.Value.ToString();
            //                    if (!string.IsNullOrEmpty(value))
            //                        ContentList = JsonConvert.DeserializeObject<List<UsrContent>>(value);
            //                    if (ContentList.Count != 0)
            //                    {
            //                        foreach (UsrContent def in ContentList)
            //                            UsrManager.CurrentUser.UserContentList.Add(def);
            //                    }
            //                }
            //                if (property.Name.Equals("reg_dt"))
            //                {
            //                    string value = property.Value.ToString();
            //                    if (!string.IsNullOrEmpty(value))
            //                        UsrManager.CurrentUser.RegistrationDate = value;
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);
            //    //Debug.WriteLine(ex.Message);
            //}

            //return user;
            //});
        }

        /// <summary>
        /// Unzip the specified zippedBuffer.
        /// </summary>
        /// <returns>The unzip.</returns>
        /// <param name="zippedBuffer">Zipped buffer.</param>
        //private static string Unzip(byte[] zippedBuffer)
        //{
        //    using (var zippedStream = new MemoryStream(zippedBuffer))
        //    {
        //        using (var archive = new ZipArchive(zippedStream))
        //        {
        //            var entry = archive.Entries.FirstOrDefault();
        //            if (entry != null)
        //            {
        //                using (var unzippedEntryStream = entry.Open())
        //                {
        //                    using (var ms = new MemoryStream())
        //                    {
        //                        unzippedEntryStream.CopyTo(ms);
        //                        var unzippedArray = ms.ToArray();

        //                        return Encoding.Default.GetString(unzippedArray);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return "";
        //}

        public void SendFCMTokenToServer(string token)
        {/*
            Task.Run(async () =>
            {
                ServerManagerResult managerResult = new ServerManagerResult();
                var stringVal = AppConstants.BASE_URL_LOGIN_API + "/SaveFirbaseToken?usrId=" + UsrManager.CurrentUser.Guid + "&deviceId=" + UsrManager.CurrentUser.DeviceId + "&token=" + token + "&deviceOs=" + UsrManager.CurrentUser.DeviceOs;
                var uri = new Uri(stringVal);
                try
                {
                    var response = httpClient.GetAsync(uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var asyncRes = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(asyncRes))
                        {
                            managerResult = JsonConvert.DeserializeObject<ServerManagerResult>(asyncRes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);
                    Debug.WriteLine(ex.Message);
                }

            });*/
        }

        
        

        

       
        //public Task<string> BuyBundleSuccess(int bundleId)
        //{
        //    return Task.Run(async () =>
        //    {
        //        string result = null;
        //        var uri = new Uri(string.Format(AppConstants.Game_URL + "buyBundleSuccess?&usr_id=" + UsrManager.CurrentUser.Guid + "&bundle_id=" + bundleId));
        //        try
        //        {
        //            var response = httpClient.GetAsync(uri).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var asyncRes = await response.Content.ReadAsStringAsync();
        //                if (!string.IsNullOrEmpty(asyncRes))
        //                    result = asyncRes;
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), e);
        //            Debug.WriteLine(e.StackTrace);
        //        }

        //        return result;
        //    });
        //}
        
        //public Task<string> GetNotifications(string guid)
        //{
        //    return Task.Run(async () =>
        //    {
        //        string fetchUrl = "http://35.184.76.85:8081/test_download/notification.json.zip";

        //        if (Barrel.Current.Exists(fetchUrl) == true && Barrel.Current.IsExpired(fetchUrl) == false)
        //        {
        //            return Barrel.Current.Get<string>(fetchUrl);
        //        }

        //        string responseStr = "";
        //        var uri = new Uri(string.Format(fetchUrl));
        //        try
        //        {
        //            Console.WriteLine(DateTime.Now);
        //            var response = httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead).Result;
        //            Console.WriteLine(DateTime.Now);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                if (fetchUrl.Contains(".zip"))
        //                {
        //                    Console.WriteLine(DateTime.Now);
        //                    responseStr = Unzip(response.Content.ReadAsByteArrayAsync().Result);
        //                    Console.WriteLine(DateTime.Now);
        //                }
        //                else
        //                {
        //                    responseStr = response.Content.ReadAsStringAsync().Result;
        //                }

        //                JObject jObject = JObject.Parse(responseStr);
        //                double ExpirySeconds = 1;

        //                if (jObject.ContainsKey("cache_expiry_dt"))
        //                {
        //                    var valuedt = jObject["cache_expiry_dt"].ToString();
        //                    if (!string.IsNullOrEmpty(valuedt))
        //                    {
        //                        DateTime expiryDateUtc = DateTime.Parse(valuedt).ToLocalTime();
        //                        if (expiryDateUtc > DateTime.Now.ToLocalTime())
        //                        {
        //                            var durationExpiry = expiryDateUtc - DateTime.Now.ToLocalTime();
        //                            ExpirySeconds = durationExpiry.TotalSeconds;
        //                        }

        //                    }
        //                }
        //                Barrel.Current.Add(fetchUrl, responseStr, TimeSpan.FromSeconds(ExpirySeconds));
        //            }

        //        }
        //        catch (Exception e)
        //        {
        //            Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), e);
        //            Debug.WriteLine("Error --> " + e.StackTrace);
        //        }

        //        return responseStr;
        //    });
        //}
        //public Task<string> GetUsrInfo()
        //{
        //    return Task.Run(async () =>
        //    {
        //        string result = null;

        //        try
        //        {

        //            var stringValue = AppConstants.Game_URL + "getUsrInfo";
        //            var uri = new Uri(stringValue);
        //            var param = "usr_id=" + UsrManager.CurrentUser.Guid;
        //            using (WebClient wc = new WebClient())
        //            {
        //                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        //                result = wc.UploadString(uri, param);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), e);
        //            Debug.WriteLine(e.StackTrace);
        //        }

        //        return result;
        //    });
        //}

        //public Task<string> GetUsrInfoByFbId()
        //{
        //    return Task.Run(async () =>
        //    {
        //        string result = null;

        //        try
        //        {

        //            var stringValue = AppConstants.Game_URL + "getUsrInfoByFbId";
        //            var uri = new Uri(stringValue);
        //            var param = "firebase_id=" + UsrManager.CurrentUser.FirebaseUserID;
        //            using (WebClient wc = new WebClient())
        //            {
        //                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        //                result = wc.UploadString(uri, param);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), e);
        //            Debug.WriteLine(e.StackTrace);
        //        }

        //        return result;
        //    });
        //}

        //public Task<string> GetBundles()
        //{
        //    return Task.Run(async () =>
        //    {
        //        string result = null;
        //        var uri = new Uri(string.Format(AppConstants.Game_URL + "getBundles?"));
        //        try
        //        {
        //            var response = httpClient.GetAsync(uri).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var asyncRes = await response.Content.ReadAsStringAsync();
        //                if (!string.IsNullOrEmpty(asyncRes))
        //                    result = asyncRes;
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Models.Utils.TrackErrors(MethodBase.GetCurrentMethod(), e);
        //            Debug.WriteLine(e.StackTrace);
        //        }

        //        return result;
        //    });
        //}

        
        
       
        
    }
}
