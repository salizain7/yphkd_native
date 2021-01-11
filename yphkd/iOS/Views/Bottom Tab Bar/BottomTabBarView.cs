using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;
using yphkd.iOS.Managers;

namespace yphkd.iOS
{
    public partial class BottomTabBarView : UIView
    {

        static UIViewController RootViewController;

        public static BaseDialogueView dialogueView;


        int currentSelectedBtnTag = 0;
        public static ShopTabView shopTabView;
        public static FriendsTabView friendsTabView;
        public static HomeTabView homeTabView;
        public static LeaderboardTabView leaderboardTabView;
        public static NotificationTabView notificationTabView;
        

        private Dictionary<UIButton, bool> buttonDictionary;

        public BottomTabBarView (IntPtr handle) : base (handle)
        {
        }
        public static BottomTabBarView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("BottomTabBarView", null, null);
            var v = arr.GetItem<BottomTabBarView>(0);
            return v;
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            buttonDictionary = new Dictionary<UIButton, bool>();
            //setupViews();
            button1.Tag = 1;
            button2.Tag = 2;
            button3.Tag = 3;
            button4.Tag = 4;
            button5.Tag = 5;

        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            setupViews();
        }
        public void setRootViewController(UIViewController uIViewController)
        {
            RootViewController = uIViewController;
            //selectButton(button4);
            showHomeTab();
        }
        private void setupViews()
        {
            //LayoutIfNeeded();

            tab1_icon.Image = UIImage.FromBundle(ImageConstants.BottomTabBar.ic_shop);
            tab2_icon.Image = UIImage.FromBundle(ImageConstants.BottomTabBar.ic_friends);
            tab3_icon.Image = UIImage.FromBundle(ImageConstants.BottomTabBar.ic_home);
            tab4_icon.Image = UIImage.FromBundle(ImageConstants.BottomTabBar.ic_leaderboard);
            tab5_icon.Image = UIImage.FromBundle(ImageConstants.BottomTabBar.ic_notifications);

            //buttonDictionary.Add(button1, false);
            //buttonDictionary.Add(button2, false);
            //buttonDictionary.Add(button3, true);
            //buttonDictionary.Add(button4, false);
            //buttonDictionary.Add(button5, false);
            
            currentSelectedBtnTag = 3;
            safeAreaView.BackgroundColor = adView.BackgroundColor = UIColor.FromRGB(21, 25, 37); 
        }

        partial void onClickBtn1(UIButton sender)
        {
            AnimationManager.Bounce(tab1_icon, onFinished: () => {
                //selectButton(button1);
                showShopTab();
                currentSelectedBtnTag = 1;
            });
        }

        partial void onClickBtn2(UIButton sender)
        {
            
            AnimationManager.Bounce(tab2_icon, onFinished: () => {
                //selectButton(button2);
                showFriendsTab();
                currentSelectedBtnTag = 2;
            });

        }
        partial void onClickBtn3(UIButton sender)
        {
            
            AnimationManager.Bounce(tab3_icon, onFinished: () => {
                //selectButton(button3);
                showHomeTab();
                currentSelectedBtnTag = 3;
            });
        }
        partial void onClickBtn4(UIButton sender)
        {
           
            AnimationManager.Bounce(tab4_icon, onFinished: () => {
                //selectButton(button4);
                showLeaderboardTab();
                currentSelectedBtnTag = 4;
            });
        }
        partial void onClickBtn5(UIButton sender)
        {
            
            AnimationManager.Bounce(tab5_icon, onFinished: () => {
                //selectButton(button5);
                AnimationManager.Scale(tab5_icon, true);
                showNotificationTab();
                currentSelectedBtnTag = 5;
            });
            
        }


        public void showHomeTab()
        {
            bool slideFromRight = false;
            slideFromRight = (int)button3.Tag < currentSelectedBtnTag;
            if (RootViewController != null )
            {
                var controller = RootViewController as HomeViewController;
                if (controller != null)
                {
                    if (currentSelectedBtnTag != 0 && (int)button3.Tag != currentSelectedBtnTag)
                    {
                        AnimationManager.SlideHorizontaly(controller.getMainView().Subviews[0], false, !slideFromRight, onFinished: () =>
                        {
                            CommonMethods.clearView(controller.getMainView());

                            homeTabView = HomeTabView.Create();
                            homeTabView.setRootViewController(RootViewController);

                            homeTabView.Frame = new CGRect(0, 0, controller.getMainView().Frame.Size.Width, controller.getMainView().Frame.Size.Height);
                            controller.getMainView().AddSubview(homeTabView);
                            AnimationManager.SlideHorizontaly(homeTabView, true, slideFromRight);

                        });
                    }
                    else
                    {
                        CommonMethods.clearView(controller.getMainView());

                        homeTabView = HomeTabView.Create();
                        homeTabView.setRootViewController(RootViewController);

                        homeTabView.Frame = new CGRect(0, 0, controller.getMainView().Frame.Size.Width, controller.getMainView().Frame.Size.Height);
                        controller.getMainView().AddSubview(homeTabView);
                    }
                    
                    
                }
            }
        }
        private void showFriendsTab()
        {
            bool slideFromRight = false;
            slideFromRight = (int)button2.Tag < currentSelectedBtnTag;

            if (RootViewController != null && (int)button2.Tag != currentSelectedBtnTag)
            {
                var controller = RootViewController as HomeViewController;
                if (controller != null)
                {
                    AnimationManager.SlideHorizontaly(controller.getMainView().Subviews[0], false, !slideFromRight, onFinished: () =>
                    {
                        CommonMethods.clearView(controller.getMainView());
                        dialogueView = BaseDialogueView.Create();
                        //CommonMethods.clearView(dialogueView.getCenterView());

                        dialogueView.setBanner(2);
                        
                        friendsTabView = FriendsTabView.Create();
                        friendsTabView.Frame = new CGRect(0, 0, dialogueView.getCenterView().Frame.Size.Width, dialogueView.getCenterView().Frame.Size.Height);
                        dialogueView.getCenterView().AddSubview(friendsTabView);


                        dialogueView.Frame = new CGRect(0, 0, controller.getMainView().Frame.Size.Width, controller.getMainView().Frame.Size.Height);
                        controller.getMainView().AddSubview(dialogueView);
                        AnimationManager.SlideHorizontaly(dialogueView, true, slideFromRight);

                    });
                    

                }
            }
        }
        private void showShopTab()
        {

            if (RootViewController != null && (int)button1.Tag != currentSelectedBtnTag)
            {
                var controller = RootViewController as HomeViewController;
                if (controller != null)
                {

                    
                    AnimationManager.SlideHorizontaly(controller.getMainView().Subviews[0], false, false, onFinished: () =>
                    {
                        CommonMethods.clearView(controller.getMainView());
                        dialogueView = BaseDialogueView.Create();

                        dialogueView.setBanner(1);
                        
                        shopTabView = ShopTabView.Create();
                        shopTabView.Frame = new CGRect(0, 0, dialogueView.getCenterView().Frame.Size.Width, dialogueView.getCenterView().Frame.Size.Height);
                        dialogueView.getCenterView().AddSubview(shopTabView);

                        dialogueView.Frame = new CGRect(0, 0, controller.getMainView().Frame.Size.Width, controller.getMainView().Frame.Size.Height);
                        controller.getMainView().AddSubview(dialogueView);
                        AnimationManager.SlideHorizontaly(dialogueView, true, true);

                    });
                    


                }
            }
        }
        private void showLeaderboardTab()
        {
            bool slideFromRight = false;
            slideFromRight = (int)button4.Tag < currentSelectedBtnTag;
            if (RootViewController != null && (int)button4.Tag != currentSelectedBtnTag)
            {
                var controller = RootViewController as HomeViewController;
                if (controller != null)
                {
                    AnimationManager.SlideHorizontaly(controller.getMainView().Subviews[0], false, !slideFromRight, onFinished: () =>
                    {
                        CommonMethods.clearView(controller.getMainView());

                        dialogueView = BaseDialogueView.Create();
                        dialogueView.setBanner(3);
                        
                        leaderboardTabView = LeaderboardTabView.Create();
                        leaderboardTabView.Frame = new CGRect(0, 0, dialogueView.getCenterView().Frame.Size.Width, dialogueView.getCenterView().Frame.Size.Height);
                        //CommonMethods.clearView(dialogueView.getCenterView());
                        dialogueView.getCenterView().AddSubview(leaderboardTabView);

                        dialogueView.Frame = new CGRect(0, 0, controller.getMainView().Frame.Size.Width, controller.getMainView().Frame.Size.Height);
                        controller.getMainView().AddSubview(dialogueView);
                        AnimationManager.SlideHorizontaly(dialogueView, true, slideFromRight);

                    });
                    

                }
            }
        }
        private void showNotificationTab()
        {
            bool slideFromRight = false;
            slideFromRight = (int)button5.Tag < currentSelectedBtnTag;
            if (RootViewController != null && (int)button5.Tag != currentSelectedBtnTag)
            {
                var controller = RootViewController as HomeViewController;
                if (controller != null)
                {
                    AnimationManager.SlideHorizontaly(controller.getMainView().Subviews[0], false, !slideFromRight, onFinished: () =>
                    {
                        CommonMethods.clearView(controller.getMainView());

                        dialogueView = BaseDialogueView.Create();
                        dialogueView.setBanner(4);
                       
                        notificationTabView = NotificationTabView.Create();
                        notificationTabView.Frame = new CGRect(0, 0, dialogueView.getCenterView().Frame.Size.Width, dialogueView.getCenterView().Frame.Size.Height);
                        //CommonMethods.clearView(dialogueView.getCenterView());
                        dialogueView.getCenterView().AddSubview(notificationTabView);


                        dialogueView.Frame = new CGRect(0, 0, controller.getMainView().Frame.Size.Width, controller.getMainView().Frame.Size.Height);
                        controller.getMainView().AddSubview(dialogueView);
                        AnimationManager.SlideHorizontaly(dialogueView, true, slideFromRight);

                    });
                    

                }
            }
        }
        private void selectButton(UIButton button)
        {
            
            foreach (KeyValuePair<UIButton, bool> item in buttonDictionary)
            {
                if (item.Key == button)
                {
                    buttonDictionary[item.Key] = true;
                    button.UserInteractionEnabled = false;
                }
            }

            DeSelectOthers();
        }
        private void DeSelectOthers()
        {
            foreach (KeyValuePair<UIButton, bool> item in buttonDictionary)
            {
                if (item.Value == true)
                {
                    buttonDictionary[item.Key] = false;
                    item.Key.UserInteractionEnabled = true;
                }
            }

        }
        public void showAdView(bool flag)
        {
            if (flag)
            {
                this.BringSubviewToFront(adView);
                
            }
            else
            {
                this.SendSubviewToBack(adView);
            }
        }

    }
}