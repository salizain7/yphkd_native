using CoreGraphics;
using Foundation;
using System;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;
using yphkd.iOS.Managers;

namespace yphkd.iOS
{
    public partial class GameTableView : UIView
    {
        PlayerView playerView;
        PlayerScoreView playerScoreView;
        UIViewController rootController;
        public GameTableView (IntPtr handle) : base (handle)
        {
        }
        public static GameTableView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("GameTableView", null, null);
            var v = arr.GetItem<GameTableView>(0);
            return v;
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            

            
            setupHands();
        }
        public void setRootController(UIViewController controller)
        {
            rootController = controller;
        }
        private void setupHands()
        {
            handImg1.Hidden = handImg2.Hidden = handImg3.Hidden = handImg4.Hidden = handImg5.Hidden = true;

            handImg1.Transform = CGAffineTransform.MakeRotation((nfloat)(Math.PI / (1 / (180f / 180f))));
            handImg2.Transform = CGAffineTransform.MakeRotation((nfloat)(Math.PI / (1 / (90f / 180f))));
            handImg3.Transform = CGAffineTransform.MakeRotation(-(nfloat)(Math.PI / (1 / (90f / 180f))));
            handImg4.Transform = CGAffineTransform.MakeRotation((nfloat)(Math.PI / (1 / (45f / 180f))));
            handImg5.Transform = CGAffineTransform.MakeRotation(-(nfloat)(Math.PI / (1 / (45f / 180f))));
        }
        public void setupPlayerView(int numberOfPlayers)
        {
            switch (numberOfPlayers)
            {
                case 3:
                    playerView = PlayerView.Create();
                    playerView.Frame = new CGRect(0, 0, playerView5.Frame.Size.Width, playerView5.Frame.Size.Height);
                    playerView.showRightRankView(true);
                    playerView5.AddSubview(playerView);
                    handImg5.Hidden = false;
                    goto case 2;
                case 2:
                    playerView = PlayerView.Create();
                    playerView.Frame = new CGRect(0, 0, playerView4.Frame.Size.Width, playerView4.Frame.Size.Height);
                    playerView.showRightRankView(false);
                    playerView4.AddSubview(playerView);
                    handImg4.Hidden = false;
                    goto case 1;
                case 1:
                    playerView = PlayerView.Create();
                    playerView.Frame = new CGRect(0, 0, playerView1.Frame.Size.Width, playerView1.Frame.Size.Height);
                    playerView.showRightRankView(true);
                    playerView1.AddSubview(playerView);
                    handImg1.Hidden = false;

                    playerView = PlayerView.Create();
                    playerView.Frame = new CGRect(0, 0, playerView2.Frame.Size.Width, playerView2.Frame.Size.Height);
                    playerView.showRightRankView(false);
                    playerView2.AddSubview(playerView);
                    handImg2.Hidden = false;

                    playerView = PlayerView.Create();
                    playerView.Frame = new CGRect(0, 0, playerView3.Frame.Size.Width, playerView3.Frame.Size.Height);
                    playerView.showRightRankView(true);
                    playerView3.AddSubview(playerView);
                    handImg3.Hidden = false;
                    break;
                default:
                    break;
            }
            

            

            
        }


        public void setupPlayerScoreView(int numberOfPlayers)
        {
            switch (numberOfPlayers)
            {
                case 3:
                    playerScoreView = PlayerScoreView.Create();
                    playerScoreView.Frame = new CGRect(0, 0, playerScoreView5.Frame.Size.Width, playerScoreView5.Frame.Size.Height);
                    playerScoreView.getPlayerBgView().BackgroundColor = ColorConstants.PlayerScoreView.playerBg5;
                    playerScoreView5.AddSubview(playerScoreView);
                    goto case 2;
                case 2:
                    playerScoreView = PlayerScoreView.Create();
                    playerScoreView.Frame = new CGRect(0, 0, playerScoreView4.Frame.Size.Width, playerScoreView4.Frame.Size.Height);
                    playerScoreView.getPlayerBgView().BackgroundColor = ColorConstants.PlayerScoreView.playerBg4;
                    playerScoreView4.AddSubview(playerScoreView);
                    goto case 1;
                case 1:
                    playerScoreView = PlayerScoreView.Create();
                    playerScoreView.Frame = new CGRect(0, 0, playerScoreView1.Frame.Size.Width, playerScoreView1.Frame.Size.Height);
                    playerScoreView.getPlayerBgView().BackgroundColor = ColorConstants.PlayerScoreView.playerBg1;
                    playerScoreView1.AddSubview(playerScoreView);

                    playerScoreView = PlayerScoreView.Create();
                    playerScoreView.Frame = new CGRect(0, 0, playerScoreView2.Frame.Size.Width, playerScoreView2.Frame.Size.Height);
                    playerScoreView.getPlayerBgView().BackgroundColor = ColorConstants.PlayerScoreView.playerBg2;
                    playerScoreView2.AddSubview(playerScoreView);

                    playerScoreView = PlayerScoreView.Create();
                    playerScoreView.Frame = new CGRect(0, 0, playerScoreView3.Frame.Size.Width, playerScoreView3.Frame.Size.Height);
                    playerScoreView.getPlayerBgView().BackgroundColor = ColorConstants.PlayerScoreView.playerBg3;
                    playerScoreView3.AddSubview(playerScoreView);
                    break;
                default:
                    break;
            }
        }
        partial void onClickBackBtn(UIButton sender)
        {
           if(rootController != null)
            {
                var homeViewcontroller = rootController as HomeViewController;
                AnimationManager.Fade(this, false, onFinished: ()=> {
                    homeViewcontroller.getBottomView().showAdView(false);

                    homeViewcontroller.getBottomView().showHomeTab();

                });
            }
        }
    }
}