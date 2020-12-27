using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;
using System.Threading.Tasks;
using UIKit;
using yphkd.Facade;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;
using yphkd.iOS.Managers;
using yphkd.ServerApi;
using yphkd.Users;

namespace yphkd.iOS
{
    public partial class SplashViewController : UIViewController
    {
        NetworkApi nwApi = new NetworkApi();
        UsrManager usrManager = new UsrManager();
        public SplashViewController() : base("SplashViewController", null)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            setupView();


            
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            //bool isFirstTime = true;
            int duration = 3;

            AnimationManager.RotateContinous(loaderImg, Duration: duration);
            Task.Run(async () => {
                await usrManager.UserAuthAsync();
                await usrManager.VerifyUser();

            });
            
            
            NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, duration*2, 0), delegate
            {
                InvokeOnMainThread(() =>
                {
                    CommonMethods.SetupHomeScreen();
                    //AnimationManager.Fade(CommonMethods.GetAppDelegate().Window, true, 0.6);
                });

            });
            

        }
        
        private void setupView()
        {
            this.View.BackgroundColor = ColorConstants.App.safeAreaBg;
            backgroundImg.Image = UIImage.FromBundle(ImageConstants.Splash.splashImage);
            backgroundImg.ContentMode = UIViewContentMode.ScaleToFill;

            loaderImg.Image = UIImage.FromBundle(ImageConstants.Splash.loaderImg);
            loaderImg.ContentMode = UIViewContentMode.ScaleAspectFit;
            loaderView.BackgroundColor = UIColor.Clear;
            

            
        }
        
    }
}