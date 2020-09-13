
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace yphkd.Droid.Classes.Login.Activites
{
    [Activity(Label = "yphkd", MainLauncher = true, Icon = "@mipmap/icon")]
    public class SplashActivity : BaseActivity
    {
        protected override void Init()
        {
            //data loads tasks starts here
        }

        protected async override void OnResume()
        {
            base.OnResume();
            ShowLoader(false);
            await Task.Delay(5000);

            NavigateToActivity(this, typeof(SelectFavHand), null, false);
        }

        protected override int SetBaseContent()
        {
            return Resource.Layout.Splash;
        }

    }
}
