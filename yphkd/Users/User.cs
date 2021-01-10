using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Essentials;
using yphkd.Model;

namespace yphkd.Users
{
    public class User
    {
        
        public string Guid { get; set; }

        public int State { get; set; }
        public string UserLang { get; set; }

        public int ISSynced { get; set; } = -100;
        public int SelectedHand { get; set; }
        public int SelectedTableType { get; set; }
        public string DeviceToken { get; set; } //firebasetoken
        public int DeviceOs { get; set; } //Device OS : 10- android , 20 -ios
        public string DeviceId { get; set; }
        public string FBToken { get; set; } //facebook
        public string FBId { get; set; } //facebook
        public string FirebaseUserID { get; set; }//firebaseid

        private static string STR_KEY = "user";

        public List<UsrContent> UserContentList { get; set; } = new List<UsrContent>();
        public UsrProfile Profile { get; set; } = new UsrProfile();
        public List<UsrProfile> UsrFriendList { get; set; } = new List<UsrProfile>();

        public void SaveToPreferences()
        {
            try
            {
                SecureStorage.SetAsync(STR_KEY, JsonConvert.SerializeObject(this)).Wait();
            }
            catch (Exception ex)
            {
                Preferences.Set(STR_KEY, JsonConvert.SerializeObject(this));
            }

        }

        public static User ReadFromPreferences()
        {
            string userStr = "";
            try
            {
                userStr = SecureStorage.GetAsync(STR_KEY).Result;
                if (userStr == null)
                    userStr = "";
            }
            catch (Exception ex)
            {
                userStr = Preferences.Get(STR_KEY, "");
            }

            var user = JsonConvert.DeserializeObject<User>(userStr);
            return user;
        }

        public void DeleteFromPreferences()
        {
            try
            {
                SecureStorage.Remove(STR_KEY);
            }
            catch (Exception ex)
            {
                Preferences.Remove(STR_KEY);
            }

        }

       
        public UsrContent GetUserContent<T>(T obj)
        {
            UsrContent usrContent = new UsrContent();
            if (obj.GetType().Equals(typeof(Hand)))
            {
                Hand playerHand = obj as Hand;
                usrContent.ContentId = playerHand.Id;
            }
            
            return usrContent;
        }
        
        public void SetFavHand(UsrContent usrContent)
        {

            int indexOF = -1;
           

            if (UserContentList != null)
            {
                var index = UserContentList.IndexOf(UserContentList.Find(c => c.IsFav.Equals(200)));
                if (index != -1 && usrContent.IsFav == 200)
                {
                    UserContentList.RemoveAt(index);
                }
                indexOF = UserContentList.IndexOf(UserContentList.Find(c => c.ContentId.Equals(usrContent.ContentId) ));
                if (indexOF != -1)
                {
                    UserContentList[indexOF] = usrContent;
                }

                else
                    UserContentList.Add(usrContent);
            }
            else
            {
                UserContentList = new List<UsrContent>();
                UserContentList.Add(usrContent);
            }
            ISSynced = -100;
            SaveToPreferences();
        }

        public bool HasAnyFavHand()
        {
            if (UserContentList != null)
            {
                if (UserContentList.Count != 0)
                {
                    foreach (UsrContent content in UserContentList)
                    {
                        if (content.IsFav == 200)
                            return true;
                    }
                }
            }
            return false;
        }

        public Hand GetFavoriteHand()
        {
            Hand playerHand = new Hand();

            playerHand.Id = 1;
            playerHand.Title = "Yassu";
            return playerHand;
            //if (UserContentList != null)
            //{
            //    if (UserContentList.Count != 0)
            //    {
            //        foreach (UsrContent content in UserContentList)
            //        {
            //            if (content.IsFav == 200)
            //            {

            //                return content.GetHand().Result;
            //            }
            //        }
            //    }

            //}
            //return null;
        }

    }
}
