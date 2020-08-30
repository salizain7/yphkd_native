using Foundation;
using System;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;

namespace yphkd.iOS
{
    public partial class PlayerView : UIView
    {
        public PlayerView (IntPtr handle) : base (handle)
        {
        }
        public static PlayerView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("PlayerView", null, null);
            var v = arr.GetItem<PlayerView>(0);
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
        }
        private void setupView()
        {
            playerHandLbl.TextColor = ColorConstants.PlayerView.playerHandText;
            playerHandLbl.BackgroundColor = ColorConstants.PlayerView.playerHandBg;
            playerHandLbl.Layer.BorderColor = ColorConstants.PlayerView.playerBgViewBorder.CGColor;
            playerHandLbl.Layer.BorderWidth = 2;
            playerHandLbl.Layer.MasksToBounds = true;
            playerHandLbl.Layer.CornerRadius = 5;

            playerNameLbl.BackgroundColor = ColorConstants.PlayerView.playerNameBg;

            playerImgBgView.Layer.BorderWidth = 2;
            playerImgBgView.Layer.CornerRadius = 8;
            playerImgBgView.Layer.BorderColor = ColorConstants.PlayerView.playerBgViewBorder.CGColor;
            playerImgBgView.Layer.MasksToBounds = true;
            playerNameLbl.TextColor = UIColor.White;

            CommonMethods.makeRoundCircle(rankViewRight);
            CommonMethods.makeRoundCircle(rankViewLeft);

            
        }
        public void showRightRankView(bool flag)
        {
            rankViewRight.Hidden = !flag;
            rankViewLeft.Hidden = flag;
        }

    }
}