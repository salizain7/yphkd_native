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
    public partial class HomeTabView : UIView
    {
        static UIViewController RootViewController;

        public static GameTableView gameTableView;
        public static BasePopupView basePopupView;

        CAGradientLayer letsPlayGradlayer;
        CAGradientLayer pwfGradlayer;
        public HomeTabView (IntPtr handle) : base (handle)
        {
        }
        public static HomeTabView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("HomeTabView", null, null);
            var v = arr.GetItem<HomeTabView>(0);

            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            
            setupText();
            
        }
        public void setRootViewController(UIViewController uIViewController)
        {
            LayoutIfNeeded();
            RootViewController = uIViewController;
            
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            setupView();
        }
        
        private void setupText()
        {
            //buttons
            
            letsPlayBtn.SetTitle("LET'S PLAY", UIControlState.Normal);
            pwfBtn.SetTitle("PLAY WITH FRIENDS", UIControlState.Normal);

            //banners
            favHandLbl.Text = "Favourite\nHand";
            loginLbl.Text = "Login";

        }
        private void setupView()
        {
            LayoutIfNeeded();

            CommonMethods.makeRoundCircle(loginIconBgView);
            CommonMethods.makeRoundCircle(favHandIconBgView);

            loginLblBgView.BackgroundColor = loginIconBgView.BackgroundColor =ColorConstants.Home.fbBanner;
            favHandBgView.BackgroundColor = favHandIconBgView.BackgroundColor = ColorConstants.Home.favHandBg;

            loginLbl.TextColor = UIColor.White;
            
            favHandLbl.TextColor = UIColor.FromRGB(211, 176, 29);

            letsPlayBtn.SetTitleColor(UIColor.White, UIControlState.Normal);
            pwfBtn.SetTitleColor(UIColor.White, UIControlState.Normal);
            
            letsPlayGradlayer = CommonMethods.addGradient(letsPlayOutterBgView, startColor: ColorConstants.Home.letsPlayBtnStartColor.CGColor, endColor: ColorConstants.Home.letsPlayBtnEndColor.CGColor);
            pwfGradlayer = CommonMethods.addGradient(pwfOutterBgView, startColor: ColorConstants.Home.PwfBtnStartColor.CGColor, endColor: ColorConstants.Home.PwfBtnEndColor.CGColor);

            //letsPlayOutterBgView.BackgroundColor = pwfOutterBgView.BackgroundColor = UIColor.White.ColorWithAlpha(0.4f);

            loginIconBgView.Layer.BorderColor = UIColor.White.CGColor;
            favHandIconBgView.Layer.BorderColor = UIColor.FromRGB(211, 176,29).CGColor;
            favHandBgView.Layer.BorderColor = UIColor.FromRGB(211, 176, 29).CGColor;
            loginLblBgView.Layer.BorderColor = UIColor.White.CGColor;

            loginLblBgView.Layer.BorderWidth = favHandBgView.Layer.BorderWidth =
            favHandIconBgView.Layer.BorderWidth = loginIconBgView.Layer.BorderWidth = 2;

            notiCountLbl.Hidden = true;
            bellIcon.Hidden = true;
            //favHandIconBgView.Layer.MasksToBounds  = loginIconBgView.Layer.MasksToBounds = true;

            letsPlayOutterBgView.Layer.CornerRadius = pwfOutterBgView.Layer.CornerRadius = 10;

            letsPlayOutterBgView.Layer.MasksToBounds = pwfOutterBgView.Layer.MasksToBounds = true;

            //CommonMethods.AddShadow(letsPlayShadowView, ColorConstants.Home.letsPlayBtnEndColor.ColorWithAlpha(0.6f),shadowOpacity: 0.6f,x: 0,y: 9,shadowRadius: 7);
            //CommonMethods.AddShadow(pwfShadowView, ColorConstants.Home.PwfBtnEndColor.ColorWithAlpha(0.6f), shadowOpacity: 0.6f, x: 0, y: 9, shadowRadius: 7);
            notiCountLbl.Layer.CornerRadius = 10.0f;
            notiCountLbl.Layer.BorderColor = UIColor.White.CGColor;
            notiCountLbl.Layer.BorderWidth = 1.0f;
            favHandIconImg.Image = UIImage.FromBundle(ImageConstants.HomeScreen.ic_fav_hand);
            loginIconImg.Image = UIImage.FromBundle(ImageConstants.HomeScreen.ic_facebook);

            //LayoutSubviews();

        }
        partial void onClickLetsPlayBtn(UIButton sender)
        {
            AnimationManager.Bounce(letsPlayOutterBgView, onFinished: ()=>
            {
                
                if (RootViewController != null)
                {
                    var controller = RootViewController as HomeViewController;
                    if (controller != null)
                    {
                        //gameTableView = GameTableView.Create();
                        //CommonMethods.clearView(controller.getMainView());
                        //controller.getMainView().AddSubview(gameTableView);
                        var popupView = controller.getPopupView();

                        popupView.Hidden = false;
                        CommonMethods.clearView(popupView);
                        popupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);


                        basePopupView = BasePopupView.Create();
                        basePopupView.showSelectTablePopup(RootViewController, "SELECT YOUR TABLE", "GO BACK", true);
                        //basePopupView.showWinnerPopup(RootViewController, "Winner of Round 1", "Home", true);
                        //basePopupView.showWinnerPopup(RootViewController, "Sorry !\n Better luck next time", "Home", true);
                        basePopupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, popupView.Frame.Height);
                        
                        controller.View.BringSubviewToFront(popupView);

                        SetUpBlurBackground(popupView);

                        AnimationManager.Fade(popupView, true, onFinished: () =>
                        {
                            popupView.AddSubview(basePopupView);
                            AnimationManager.SlideVerticaly(basePopupView, true, true);

                        });
                       


                    }
                }
            });

        }
        private void SetUpBlurBackground(UIView view)
        {
            this.BackgroundColor = UIColor.Clear;


            UIVisualEffect blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);
            UIVisualEffectView visualEffectView = new UIVisualEffectView(blurEffect);
            visualEffectView.Frame = new CGRect(0, 0, view.Frame.Width, view.Frame.Height);
            visualEffectView.Alpha = 0.90f;

            view.Layer.MasksToBounds = true;

            view.AddSubview(visualEffectView);
            
        }
        partial void onClickPwfBtn(UIButton sender)
        {
            AnimationManager.Bounce(pwfOutterBgView);
        }

    }
}