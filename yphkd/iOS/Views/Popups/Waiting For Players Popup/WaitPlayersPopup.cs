using Foundation;
using System;
using UIKit;

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
        }
        private void setupView()
        {
            this.BackgroundColor = UIColor.Clear;
            waitingLbl.Text = "Waiting for players...";
            timerLbl.Text = "30";
        }
    }
}