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
            letsPlayGradlayer.Frame = new CGRect(0, 0, letsPlayInnerBgView.Frame.Width, letsPlayInnerBgView.Frame.Height + 100); ;
            pwfGradlayer.Frame = new CGRect(0, 0, pwfInnerBgView.Frame.Width, pwfInnerBgView.Frame.Height + 100);
        }
        
        private void setupText()
        {
            //buttons
            
            letsPlayBtn.SetTitle("LETS PLAY", UIControlState.Normal);
            pwfBtn.SetTitle("PLAY WITH FRIENDS", UIControlState.Normal);

            //banners
            favHandLbl.Text = "Favourite\nHand";
            loginLbl.Text = "Login";
            inviteFriendsLbl.Text = "Invite Friends";

        }
        private void setupView()
        {
            LayoutIfNeeded();

            CommonMethods.makeRoundCircle(loginIconBgView);
            CommonMethods.makeRoundCircle(inviteFriendsIconBgView);
            CommonMethods.makeRoundCircle(favHandIconBgView);

            loginLblBgView.BackgroundColor = loginIconBgView.BackgroundColor =
                inviteFriendsBgView.BackgroundColor = inviteFriendsIconBgView.BackgroundColor = ColorConstants.Home.fbBanner;
            favHandBgView.BackgroundColor = favHandIconBgView.BackgroundColor = ColorConstants.Home.favHandBg;

            loginLbl.TextColor = inviteFriendsLbl.TextColor = favHandLbl.TextColor = UIColor.White;

            letsPlayBtn.SetTitleColor(UIColor.White, UIControlState.Normal);
            pwfBtn.SetTitleColor(UIColor.White, UIControlState.Normal);

            letsPlayBtnWhiteBorderBgView.BackgroundColor = pwfBtnWhiteBorderBgView.BackgroundColor = UIColor.Clear;
            letsPlayGradlayer = CommonMethods.addGradient(letsPlayInnerBgView, startColor: ColorConstants.Home.letsPlayBtnStartColor.CGColor, endColor: ColorConstants.Home.letsPlayBtnEndColor.CGColor);
            pwfGradlayer = CommonMethods.addGradient(pwfInnerBgView, startColor: ColorConstants.Home.PwfBtnStartColor.CGColor, endColor: ColorConstants.Home.PwfBtnEndColor.CGColor);
            letsPlayOutterBgView.BackgroundColor = pwfOutterBgView.BackgroundColor = UIColor.White.ColorWithAlpha(0.4f);

            letsPlayBtnWhiteBorderBgView.Layer.BorderColor = pwfBtnWhiteBorderBgView.Layer.BorderColor =
                 favHandIconBgView.Layer.BorderColor = loginIconBgView.Layer.BorderColor =
                 inviteFriendsIconBgView.Layer.BorderColor = UIColor.White.CGColor;

            letsPlayBtnWhiteBorderBgView.Layer.BorderWidth = pwfBtnWhiteBorderBgView.Layer.BorderWidth = 2;
            favHandIconBgView.Layer.BorderWidth = loginIconBgView.Layer.BorderWidth =
                 inviteFriendsIconBgView.Layer.BorderWidth = 1;


            //letsPlayShadowView.Layer.CornerRadius = pwfShadowView.Layer.CornerRadius =
            //    letsPlayInnerBgView.Layer.CornerRadius = pwfInnerBgView.Layer.CornerRadius = letsPlayInnerBgView.Frame.Width / 7.0f;

            //letsPlayOutterBgView.Layer.CornerRadius = pwfOutterBgView.Layer.CornerRadius = letsPlayOutterBgView.Frame.Width / 6.0f;

            //letsPlayBtnWhiteBorderBgView.Layer.CornerRadius =
            //    pwfBtnWhiteBorderBgView.Layer.CornerRadius = letsPlayBtnWhiteBorderBgView.Frame.Width / 8.0f;

            letsPlayShadowView.Layer.CornerRadius = pwfShadowView.Layer.CornerRadius =
    letsPlayInnerBgView.Layer.CornerRadius = pwfInnerBgView.Layer.CornerRadius = letsPlayInnerBgView.Frame.Height / 2.0f;

            letsPlayOutterBgView.Layer.CornerRadius = pwfOutterBgView.Layer.CornerRadius = letsPlayOutterBgView.Frame.Height / 2.0f;

            letsPlayBtnWhiteBorderBgView.Layer.CornerRadius =
                pwfBtnWhiteBorderBgView.Layer.CornerRadius = letsPlayBtnWhiteBorderBgView.Frame.Height / 2.0f;

            //letsPlayShadowView.Layer.CornerRadius = pwfShadowView.Layer.CornerRadius =
            //    letsPlayInnerBgView.Layer.CornerRadius = pwfInnerBgView.Layer.CornerRadius = letsPlayInnerBgView.Frame.Width / 8;
            //letsPlayOutterBgView.Layer.CornerRadius = pwfOutterBgView.Layer.CornerRadius = letsPlayOutterBgView.Frame.Width / 6;
            //letsPlayBtnWhiteBorderBgView.Layer.CornerRadius =
            //    pwfBtnWhiteBorderBgView.Layer.CornerRadius = letsPlayBtnWhiteBorderBgView.Frame.Width / 10;

            letsPlayBtnWhiteBorderBgView.Layer.MasksToBounds = letsPlayInnerBgView.Layer.MasksToBounds =
                letsPlayOutterBgView.Layer.MasksToBounds = pwfBtnWhiteBorderBgView.Layer.MasksToBounds =
                pwfInnerBgView.Layer.MasksToBounds = pwfOutterBgView.Layer.MasksToBounds = true;

            

            CommonMethods.AddShadow(letsPlayShadowView, ColorConstants.Home.letsPlayBtnEndColor.ColorWithAlpha(0.6f),shadowOpacity: 0.6f,x: 0,y: 9,shadowRadius: 7);
            CommonMethods.AddShadow(pwfShadowView, ColorConstants.Home.PwfBtnEndColor.ColorWithAlpha(0.6f), shadowOpacity: 0.6f, x: 0, y: 9, shadowRadius: 7);

            favHandIconImg.Image = UIImage.FromBundle(ImageConstants.HomeScreen.ic_fav_hand);
            inviteFriendsIconImg.Image = UIImage.FromBundle(ImageConstants.HomeScreen.ic_share);
            loginIconImg.Image = UIImage.FromBundle(ImageConstants.HomeScreen.ic_facebook);

            //LayoutSubviews();

        }
        partial void onClickLetsPlayBtn(UIButton sender)
        {
            AnimationManager.Bounce(letsPlayShadowView, onFinished: ()=>
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
            AnimationManager.Bounce(pwfShadowView);
        }

    }
}