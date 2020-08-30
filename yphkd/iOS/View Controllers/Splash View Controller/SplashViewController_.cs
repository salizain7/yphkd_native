using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;
using yphkd.iOS.Managers;


namespace yphkd.iOS
{
    public partial class SplashViewController : UIViewController
    {
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
            bool isFirstTime = true;
            int duration = 3;
            AnimationManager.RotateContinous(loaderImg, Duration: duration);
            NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, duration*2, 0), delegate
            {
                InvokeOnMainThread(() =>
                {
                    if (isFirstTime)
                    {
                        CommonMethods.SetupTutorialScreen();
                    }
                    else
                    {
                        CommonMethods.SetupHomeScreen();
                    }
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