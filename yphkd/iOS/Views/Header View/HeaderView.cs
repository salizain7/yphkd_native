using Foundation;
using System;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;

namespace yphkd.iOS
{
    public partial class HeaderView : UIView
    {
        public HeaderView (IntPtr handle) : base (handle)
        {
        }

        public static HeaderView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("HeaderView", null, null);
            var v = arr.GetItem<HeaderView>(0);

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
        public void setupView()
        {
            usernameLbl.TextColor = coinsLbl.TextColor = usrBadgeLbl.TextColor = UIColor.White;

            coinsBgView.BackgroundColor = ColorConstants.Header.coinsLblBg;
            coinsBgView.Layer.BorderColor = ColorConstants.Header.coinsLblBgViewBorder.CGColor;
            progressBarView.Layer.BorderWidth = coinsBgView.Layer.BorderWidth = 1;

            progressBarView.Layer.BorderColor = ColorConstants.Header.progressBarBorder.CGColor;
            progressBarView.ProgressTintColor = ColorConstants.Header.coinsLblBgViewBorder;
            progressBarView.TrackTintColor = ColorConstants.Header.progressTrackTint;


            CommonMethods.addGradient(safeAreaView, startColor: ColorConstants.Header.startColor.CGColor, endColor: ColorConstants.Header.endColor.CGColor);
            CommonMethods.addGradient(this, startColor: ColorConstants.Header.startColor.CGColor, endColor: ColorConstants.Header.endColor.CGColor);
            //this.BackgroundColor = UIColor.White;
            coinsImgFrame.Image = UIImage.FromBundle(ImageConstants.Header.user_coins);
            profileImgFrame.Image = UIImage.FromBundle(ImageConstants.Common.placeholder_img);

        }
    }
}