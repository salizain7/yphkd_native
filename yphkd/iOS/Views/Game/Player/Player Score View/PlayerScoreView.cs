using Foundation;
using System;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;

namespace yphkd.iOS
{
    public partial class PlayerScoreView : UIView
    {
        public PlayerScoreView (IntPtr handle) : base (handle)
        {
        }
        public static PlayerScoreView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("PlayerScoreView", null, null);
            var v = arr.GetItem<PlayerScoreView>(0);
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
            playerImgBgView.Layer.BorderWidth = 2;
            playerImgBgView.Layer.BorderColor = UIColor.White.CGColor;
            
            CommonMethods.makeRoundCircle(playerImgBgView);

            playerHandLbl.TextColor = UIColor.White;
            separator1.BackgroundColor = UIColor.White;
            separator2.BackgroundColor = UIColor.FromRGB(34, 88, 26);

            playerImg.Image = UIImage.FromBundle( ImageConstants.Common.placeholder_img);
            
        }
        public void BindData()
        {

        }
        public UIView getPlayerBgView()
        {
            return playerScoreBgView;
        }
    }
}