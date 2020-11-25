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
            rankViewRight.Hidden = rankViewLeft.Hidden = true;

        }
        public void setRankPosition(bool isOnRight)
        {
            isOnRightSideOfTable = isOnRight;
            
        }
        public void BindData(string name, string favHand, string image = "")
        {
            playerHandLbl.Text = favHand;
            playerNameLbl.Text = name;

            if (!string.IsNullOrEmpty(image))
            {
                var url = new NSUrl(image);
                var data = NSData.FromUrl(url);
                playerImg.Image = UIImage.LoadFromData(data);
            }
            
        }
        public void ShowWinnerRank(string rank)
        {
            if (isOnRightSideOfTable)
            {
                rankViewRight.Hidden = false;
                rankLblRight.Text = rank;
            } else
            {
                rankViewLeft.Hidden = false;
                rankLblLeft.Text = rank;
            }
        }

    }
}