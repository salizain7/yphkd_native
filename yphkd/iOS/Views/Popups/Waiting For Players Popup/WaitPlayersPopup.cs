using Foundation;
using System;
using UIKit;
using yphkd.iOS.Constants;
using yphkd.iOS.Managers;

namespace yphkd.iOS
{
    public partial class WaitPlayersPopup : UIView
    {
        public WaitPlayersPopup(IntPtr handle) : base(handle)
        {
        }
        public static WaitPlayersPopup Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("WaitPlayersPopup", null, null);
            var v = arr.GetItem<WaitPlayersPopup>(0);

            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            setupView();
            //SetUpBlurBackground();
            AnimationManager.RotateContinous(loaderImg, Duration: 5);
        }
        private void setupView()
        {
            this.BackgroundColor = UIColor.Clear;
            waitingLbl.Text = "Waiting for players...";
            timerLbl.Text = "5";

            loaderImg.Image = UIImage.FromBundle(ImageConstants.Splash.loaderImg);
            loaderImg.ContentMode = UIViewContentMode.ScaleAspectFit;
            loaderBgView.BackgroundColor = UIColor.Clear;
        }
        public void SetupCountDown()
        {
            NSTimer TimeLeftTimer = null;
            int TimeLeft = 5;
            if (TimeLeftTimer == null)
            {
                TimeLeftTimer = NSTimer.CreateRepeatingScheduledTimer(new TimeSpan(0, 0, 1), (NSTimer obj) =>
                {
                    if (TimeLeft > 0)
                    {
                        TimeLeft--;

                        timerLbl.Text = TimeLeft.ToString();
                    }
                    else if (TimeLeft == 0)
                    {
                        TimeLeftTimer.Invalidate();
                        TimeLeftTimer = null;
                        AnimationManager.Fade(this.Superview, false, onFinished: ()=> {
                            this.Superview.RemoveFromSuperview();

                        });
                    }
                });
            }
        }
        
        
    }
}