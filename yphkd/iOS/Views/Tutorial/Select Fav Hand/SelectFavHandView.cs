using Foundation;
using System;
using UIKit;
using yphkd.iOS.ViewControllers.Tutorial;

namespace yphkd.iOS
{
    public partial class SelectFavHandView : UIView
    {
        int borderWidth = 3;
        UIColor borderColor = UIColor.Yellow;
        UIViewController rootController;
        
        public SelectFavHandView(IntPtr handle) : base(handle)
        {
        }
        public static SelectFavHandView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("SelectFavHandView", null, null);
            var v = arr.GetItem<SelectFavHandView>(0);
            return v;
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            setupView();
            //SetUpBlurBackground();
        }
        public void setRootController(UIViewController parentController)
        {
            rootController = parentController;
            var controller = rootController as TutorialViewController;
            if (controller != null && controller.handleIsSelected == false ) 
            {
                controller.EnableContinueBtn(false);
            }

        }
        private void setupView()
        {
            handView1.Layer.CornerRadius = handView2.Layer.CornerRadius = handView3.Layer.CornerRadius =
                handView4.Layer.CornerRadius = handView5.Layer.CornerRadius = 10;
            handView1.Layer.MasksToBounds = handView2.Layer.MasksToBounds = handView3.Layer.MasksToBounds =
                    handView4.Layer.MasksToBounds = handView5.Layer.MasksToBounds = true;
        }
        public void setSelected(int viewNo)
        {
            
            switch (viewNo)
            {
                case 1:

                    handView1.Layer.BorderWidth = borderWidth;
                    handView1.Layer.BorderColor = borderColor.CGColor;

                    handView2.Layer.BorderWidth = handView3.Layer.BorderWidth =
                    handView4.Layer.BorderWidth = handView5.Layer.BorderWidth = 0;

                    handView2.Layer.BorderColor = handView3.Layer.BorderColor =
                    handView4.Layer.BorderColor = handView5.Layer.BorderColor = UIColor.Clear.CGColor;
                    break;
                case 2:
                    handView2.Layer.BorderWidth = borderWidth;
                    handView2.Layer.BorderColor = borderColor.CGColor;

                    handView1.Layer.BorderWidth = handView3.Layer.BorderWidth =
                    handView4.Layer.BorderWidth = handView5.Layer.BorderWidth = 0;

                    handView1.Layer.BorderColor = handView3.Layer.BorderColor =
                    handView4.Layer.BorderColor = handView5.Layer.BorderColor = UIColor.Clear.CGColor;
                    break;
                case 3:
                    handView3.Layer.BorderWidth = borderWidth;
                    handView3.Layer.BorderColor = borderColor.CGColor;

                    handView2.Layer.BorderWidth = handView1.Layer.BorderWidth =
                    handView4.Layer.BorderWidth = handView5.Layer.BorderWidth = 0;

                    handView2.Layer.BorderColor = handView1.Layer.BorderColor =
                    handView4.Layer.BorderColor = handView5.Layer.BorderColor = UIColor.Clear.CGColor;
                    break;
                case 4:
                    handView4.Layer.BorderWidth = borderWidth;
                    handView4.Layer.BorderColor = borderColor.CGColor;

                    handView2.Layer.BorderWidth = handView3.Layer.BorderWidth =
                    handView1.Layer.BorderWidth = handView5.Layer.BorderWidth = 0;

                    handView2.Layer.BorderColor = handView3.Layer.BorderColor =
                    handView1.Layer.BorderColor = handView5.Layer.BorderColor = UIColor.Clear.CGColor;
                    break;
                case 5:
                    handView5.Layer.BorderWidth = borderWidth;
                    handView5.Layer.BorderColor = borderColor.CGColor;

                    handView2.Layer.BorderWidth = handView3.Layer.BorderWidth =
                    handView4.Layer.BorderWidth = handView1.Layer.BorderWidth = 0;

                    handView2.Layer.BorderColor = handView3.Layer.BorderColor =
                    handView4.Layer.BorderColor = handView1.Layer.BorderColor = UIColor.Clear.CGColor;
                    break;


            }
            var controller = rootController as TutorialViewController;
            if (controller != null)
            {
                controller.EnableContinueBtn(true);
                controller.handleIsSelected = true;
            }
        }
        partial void onClickHandBtn1(UIButton sender)
        {
            setSelected(1);

        }
        partial void onClickHandBtn2(UIButton sender)
        {
            setSelected(2);
        }
        partial void onClickHandBtn3(UIButton sender)
        {
            setSelected(3);
        }
        partial void onClickHandBtn4(UIButton sender)
        {
            setSelected(4);
        }
        partial void onClickHandBtn5(UIButton sender)
        {
            setSelected(5);
        }
    }
}