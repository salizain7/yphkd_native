using Foundation;
using System;
using UIKit;
using yphkd.Facade;
using yphkd.iOS.Constants;

namespace yphkd.iOS
{
    public partial class SelectHandPopupView : UIView
    {
        int borderWidth = 3;
        UIColor borderColor = UIColor.Yellow;
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

            imageBg1.Layer.CornerRadius = imageBg2.Layer.CornerRadius = imageBg3.Layer.CornerRadius =
                imageBg4.Layer.CornerRadius = imageBg5.Layer.CornerRadius = 10;
            imageBg1.Layer.MasksToBounds = imageBg2.Layer.MasksToBounds = imageBg3.Layer.MasksToBounds =
                    imageBg4.Layer.MasksToBounds = imageBg5.Layer.MasksToBounds = true;

            image1.Image = UIImage.FromBundle(ImageConstants.Hands.hand_1);
            image2.Image = UIImage.FromBundle(ImageConstants.Hands.hand_2);
            image3.Image = UIImage.FromBundle(ImageConstants.Hands.hand_3);
            image4.Image = UIImage.FromBundle(ImageConstants.Hands.hand_4);
            image5.Image = UIImage.FromBundle(ImageConstants.Hands.hand_5);
        }
        public void setSelected(int viewNo)
        {
            UsrManager.CurrentUser.SelectedHand = viewNo;
            switch (viewNo)
            {
                case 1:

                    imageBg1.Layer.BorderWidth = borderWidth;
                    imageBg1.Layer.BorderColor = borderColor.CGColor;

                    imageBg2.Layer.BorderWidth = imageBg3.Layer.BorderWidth =
                    imageBg4.Layer.BorderWidth = imageBg5.Layer.BorderWidth = 0;

                    imageBg2.Layer.BorderColor = imageBg3.Layer.BorderColor =
                    imageBg4.Layer.BorderColor = imageBg5.Layer.BorderColor = UIColor.Clear.CGColor;
                    break;
                case 2:
                    imageBg2.Layer.BorderWidth = borderWidth;
                    imageBg2.Layer.BorderColor = borderColor.CGColor;

                    imageBg1.Layer.BorderWidth = imageBg3.Layer.BorderWidth =
                    imageBg4.Layer.BorderWidth = imageBg5.Layer.BorderWidth = 0;

                    imageBg1.Layer.BorderColor = imageBg3.Layer.BorderColor =
                    imageBg4.Layer.BorderColor = imageBg5.Layer.BorderColor = UIColor.Clear.CGColor;
                    break;
                case 3:
                    imageBg3.Layer.BorderWidth = borderWidth;
                    imageBg3.Layer.BorderColor = borderColor.CGColor;

                    imageBg2.Layer.BorderWidth = imageBg1.Layer.BorderWidth =
                    imageBg4.Layer.BorderWidth = imageBg5.Layer.BorderWidth = 0;

                    imageBg2.Layer.BorderColor = imageBg1.Layer.BorderColor =
                    imageBg4.Layer.BorderColor = imageBg5.Layer.BorderColor = UIColor.Clear.CGColor;
                    break;
                case 4:
                    imageBg4.Layer.BorderWidth = borderWidth;
                    imageBg4.Layer.BorderColor = borderColor.CGColor;

                    imageBg2.Layer.BorderWidth = imageBg3.Layer.BorderWidth =
                    imageBg1.Layer.BorderWidth = imageBg5.Layer.BorderWidth = 0;

                    imageBg2.Layer.BorderColor = imageBg3.Layer.BorderColor =
                    imageBg1.Layer.BorderColor = imageBg5.Layer.BorderColor = UIColor.Clear.CGColor;
                    break;
                case 5:
                    imageBg5.Layer.BorderWidth = borderWidth;
                    imageBg5.Layer.BorderColor = borderColor.CGColor;

                    imageBg2.Layer.BorderWidth = imageBg3.Layer.BorderWidth =
                    imageBg4.Layer.BorderWidth = imageBg1.Layer.BorderWidth = 0;

                    imageBg2.Layer.BorderColor = imageBg3.Layer.BorderColor =
                    imageBg4.Layer.BorderColor = imageBg1.Layer.BorderColor = UIColor.Clear.CGColor;
                    break;


            }

        }
        partial void onClickBtn1(UIButton sender)
        {
            setSelected(1);

        }
        partial void onClickBtn2(UIButton sender)
        {
            setSelected(2);
        }
        partial void onClickBtn3(UIButton sender)
        {
            setSelected(3);
        }
        partial void onClickBtn4(UIButton sender)
        {
            setSelected(4);
        }
        partial void onClickBtn5(UIButton sender)
        {
            setSelected(5);
        }
    }
}