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
        bool isOnRightSideOfTable = false;
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
            playerHand.TextColor = ColorConstants.PlayerView.playerHandText;
            //playerHandLbl.BackgroundColor = ColorConstants.PlayerView.playerHandBg;
            //playerHandLbl.Layer.BorderColor = ColorConstants.PlayerView.playerBgViewBorder.CGColor;
            //playerHandLbl.Layer.BorderWidth = 2;
            //playerHandLbl.Layer.MasksToBounds = true;
            //playerHandLbl.Layer.CornerRadius = 5;

            playerImg.Layer.BorderWidth = 2;
            playerImg.Layer.BorderColor = UIColor.White.CGColor;
           
            CommonMethods.makeRoundCircle(playerImg);
           
        }
        public void setRankPosition(bool isOnRight)
        {
            isOnRightSideOfTable = isOnRight;
            
        }
        public void BindData(string name, string favHand, string image = "")
        {
            playerHand.Text = favHand;
            playerName.Text = name;

            if (!string.IsNullOrEmpty(image))
            {
                var url = new NSUrl(image);
                var data = NSData.FromUrl(url);
                playerImg.Image = UIImage.LoadFromData(data);
            }
            
        }
        

    }
}