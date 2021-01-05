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
            usernameLbl.TextColor = coinsLbl.TextColor =  UIColor.White;

            //coinsBgView.BackgroundColor = ColorConstants.Header.coinsLblBg;
            coinsBgView.Layer.BorderColor = ColorConstants.Header.coinsLblBgViewBorder.CGColor;
            coinsBgView.Layer.CornerRadius = 6;
            coinsBgView.Layer.ShadowColor = ColorConstants.Header.coinsLblBgViewBorder.CGColor;
            coinsBgView.Layer.ShadowOffset = new CoreGraphics.CGSize(new CoreGraphics.CGPoint(x: 0, y: 0));
            coinsBgView.Layer.ShadowOpacity = 6;

            progressBarView.Layer.BorderWidth = coinsBgView.Layer.BorderWidth = 0.2f;
            progressBarView.Layer.CornerRadius = progressBarView.Frame.Height;

            progressBarView.Layer.BorderColor = ColorConstants.Header.progressBarBorder.CGColor;
            progressBarView.ProgressTintColor = ColorConstants.Header.progressBarBorder;
            progressBarView.TrackTintColor = ColorConstants.Header.progressTrackTint;
            //progressBarView.ProgressImage = UIImage.FromBundle("progress_image");
            progressBarView.Layer.Sublayers[1].ShadowColor = UIColor.FromRGB(42, 190, 130).CGColor;
            progressBarView.Layer.Sublayers[1].ShadowOffset = new CoreGraphics.CGSize(new CoreGraphics.CGPoint(x: 0, y: 0));
            progressBarView.Layer.Sublayers[1].ShadowOpacity = (float)(progressBarView.Frame.Height - 2);

            safeAreaView.BackgroundColor = this.BackgroundColor = UIColor.FromRGB(21, 25, 37); 
            //CommonMethods.addGradient(safeAreaView, startColor: ColorConstants.Header.startColor.CGColor, endColor: ColorConstants.Header.endColor.CGColor);
            //CommonMethods.addGradient(this, startColor: ColorConstants.Header.startColor.CGColor, endColor: ColorConstants.Header.endColor.CGColor);
            //this.BackgroundColor = UIColor.White;
            coinsImgFrame.Image = UIImage.FromBundle(ImageConstants.Header.user_coins);
            profileImgFrame.Image = UIImage.FromBundle(ImageConstants.Common.placeholder_img);

            

        }
    }
}