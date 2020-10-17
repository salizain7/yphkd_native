using Foundation;
using System;
using UIKit;

namespace yphkd.iOS
{
    public partial class SelectHandPopupView : UIView
    {
        public SelectHandPopupView (IntPtr handle) : base (handle)
        {
        }
        public static SelectHandPopupView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("SelectHandPopupView", null, null);
            var v = arr.GetItem<SelectHandPopupView>(0);

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
            imageBg1.BackgroundColor = imageBg2.BackgroundColor =
                imageBg3.BackgroundColor = imageBg4.BackgroundColor =
                imageBg5.BackgroundColor = UIColor.Clear;

            image1.Image = UIImage.FromBundle("ic_one_finger");
            image2.Image = UIImage.FromBundle("ic_two_finger");
            image3.Image = UIImage.FromBundle("ic_three_finger");
            image4.Image = UIImage.FromBundle("ic_four_finger");
            image5.Image = UIImage.FromBundle("ic_five_finger");
        }
    }
}