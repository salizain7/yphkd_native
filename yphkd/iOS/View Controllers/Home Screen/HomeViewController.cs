using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;
using yphkd.iOS.Managers;

namespace yphkd.iOS
{
    public partial class HomeViewController : UIViewController
    {
        public static BottomTabBarView bottomView;
        public static HeaderView headerView;
        BasePopupView basePopupView;

        public HomeViewController() : base("HomeViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if(NavigationController != null)
            {
                NavigationController.NavigationBarHidden = true;
            }

        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
       
            setupView();
            this.View.SendSubviewToBack(popupView);
        }
        
        private void setupView()
        {
            
            this.View.BackgroundColor = ColorConstants.App.safeAreaBg;
            backgroundImg.Image = UIImage.FromBundle(ImageConstants.HomeScreen.homeBackgroundImage);
            backgroundImg.ContentMode = UIViewContentMode.ScaleToFill;

            HeaderBgView.BackgroundColor = UIColor.Clear;

            bottomView = BottomTabBarView.Create();
            bottomView.Frame = new CGRect(0, 0, BottomTabBarBgView.Frame.Size.Width, BottomTabBarBgView.Frame.Size.Height);
            BottomTabBarBgView.AddSubview(bottomView);

            headerView = HeaderView.Create();
            
            headerView.Frame = new CGRect(0, 0, HeaderBgView.Frame.Size.Width, HeaderBgView.Frame.Size.Height);
            HeaderBgView.AddSubview(headerView);
            
            bottomView.setRootViewController(this);

            //if first time
            showHandSelectionPopup();


        }
        private void showHandSelectionPopup()
        {
            popupView.Hidden = false;   
            
            CommonMethods.clearView(popupView);
            popupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);

            basePopupView = BasePopupView.Create();
            basePopupView.showSelectHandPopup(this, "SELECT FAVOURITE HAND", "", false);
            //basePopupView.showWinnerPopup(RootViewController, "Winner of Round 1", "Home", true);
            //basePopupView.showWinnerPopup(RootViewController, "Sorry !\n Better luck next time", "Home", true);
            basePopupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, popupView.Frame.Height);



            CommonMethods.SetUpBlurBackground(popupView);



            AnimationManager.Fade(popupView, true, onFinished: () =>
            {
                popupView.AddSubview(basePopupView);
                this.View.BringSubviewToFront(popupView);
            });
        }
        public UIView getMainView()
        {
            return MainView;
        }
        public UIView getPopupView()
        {
            
            return popupView;
        }
        public BottomTabBarView getBottomView()
        {
            return bottomView;
        }
    }
}