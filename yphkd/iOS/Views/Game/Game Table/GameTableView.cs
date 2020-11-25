using CoreGraphics;
using Foundation;
using System;
using UIKit;
using yphkd.Facade;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;
using yphkd.iOS.Managers;
using yphkd.Model.Game;
using yphkd.Model.GameDefinition;
using yphkd.Model.ServerResults;

namespace yphkd.iOS
{
    public partial class GameTableView : UIView
    {
        PlayerView playerView_1;
        PlayerView playerView_2;
        PlayerView playerView_3;
        PlayerView playerView_4;
        PlayerView playerView_5;

        PlayerScoreView playerScoreView;
        UIViewController rootController;
        BasePopupView basePopupView;


        UserPlayRequestResult usrPlayReqResult = new UserPlayRequestResult();
        GameRoundWinnerResult gameRoundWinnerResult = new GameRoundWinnerResult();

        int roundNo = 1;
        public static WaitPlayersPopup waitPlayerPopup;

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
            //showWaitingPopup();
        }
        public void setRootController(UIViewController controller)
        {
            rootController = controller;
        }
        public void showWaitingPopup()
        {
            var homeViewcontroller = rootController as HomeViewController;
            if (homeViewcontroller != null)
            {
                var popupView = homeViewcontroller.getPopupView();

                popupView.Hidden = false;
                CommonMethods.clearView(popupView);
                popupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);

                waitPlayerPopup = WaitPlayersPopup.Create();
                //basePopupView.showSelectTablePopup(RootViewController, "SELECT YOUR TABLE", "GO BACK", true);
                //basePopupView.showWinnerPopup(RootViewController, "Winner of Round 1", "Home", true);
                //basePopupView.showWinnerPopup(RootViewController, "Sorry !\n Better luck next time", "Home", true);
                waitPlayerPopup.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, popupView.Frame.Height);


                homeViewcontroller.View.BringSubviewToFront(popupView);

                CommonMethods.SetUpBlurBackground(popupView);



                AnimationManager.Fade(popupView, true, onFinished: () =>
                {
                    popupView.AddSubview(waitPlayerPopup);
                    startFindingPlayers(popupView);


                    
                    //AnimationManager.SlideVerticaly(waitPlayerPopup, true, true);

                });
            }

                
        }
        
        private void startFindingPlayers(UIView popupView)
        {
            NSTimer TimeLeftTimer = null;
            int TimeLeft = 5;
            if (TimeLeftTimer == null)
            {
                TimeLeftTimer = NSTimer.CreateRepeatingScheduledTimer(new TimeSpan(0, 0, 1), async (NSTimer obj) =>
                {
                    if (TimeLeft > 0)
                    {
                        TimeLeft--;
                        waitPlayerPopup.BindData(TimeLeft);
                        
                    }
                    if (TimeLeft == 3)
                    {
                        GameManager gameManager = new GameManager();
                        usrPlayReqResult = await gameManager.UserPlayRequest(GameEnums.GetTableType(UsrManager.CurrentUser.SelectedTableType));
                    }
                    
                    else if (TimeLeft == 0)
                    {
                        TimeLeftTimer.Invalidate();
                        TimeLeftTimer = null;

                        AnimationManager.Fade(popupView, false, onFinished: () =>
                        {
                            popupView.Hidden = true;
                            StartGamePlay(popupView);

                        });
                        
                    }
                    
                });
            }
            
        }
        private void StartGamePlay(UIView popupView)
        {
            if(roundNo < UsrManager.CurrentUser.SelectedTableType)
            {
                
                roundNoLbl.Text = "Round " + roundNo;
                NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, 3), delegate
                {
                    showSelectHandPopup(popupView);
                });

            }
            else
            {
                roundNoLbl.Text = "Game Over";
            }
            
        }
        private void showSelectHandPopup(UIView popupView)
        {
            popupView.Hidden = false;
            CommonMethods.clearView(popupView);
            popupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);

            basePopupView = BasePopupView.Create();
            basePopupView.showSelectHandPopup(rootController, "SELECT ANY HAND","", false, handId: UsrManager.CurrentUser.GetFavoriteHand().Id);
            //basePopupView.showWinnerPopup(RootViewController, "Winner of Round 1", "Home", true);
            //basePopupView.showWinnerPopup(RootViewController, "Sorry !\n Better luck next time", "Home", true);
            basePopupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, popupView.Frame.Height);

            this.BringSubviewToFront(popupView);

            CommonMethods.SetUpBlurBackground(popupView);



            AnimationManager.Fade(popupView, true, onFinished: () =>
            {
                popupView.AddSubview(basePopupView);
                setupSelectionTimer(basePopupView, popupView);
            });
        }
        public void setupSelectionTimer(BasePopupView basePopupView, UIView superView)
        {
            NSTimer TimeLeftTimer = null;
            int TimeLeft = 5;
            if (TimeLeftTimer == null)
            {
                TimeLeftTimer = NSTimer.CreateRepeatingScheduledTimer(new TimeSpan(0, 0, 1), (NSTimer obj) =>
                {
                    if (TimeLeft > 0)
                    {
                        TimeLeft--;
                        basePopupView.setBtnTitle("Time: " + TimeLeft.ToString());

                    }
                    
                    else if (TimeLeft == 0)
                    {
                        TimeLeftTimer.Invalidate();
                        TimeLeftTimer = null;

                        // hide select hand popup
                        AnimationManager.Fade(superView, false, onFinished: async () =>
                        {
                            GameManager gameManager = new GameManager();
                            basePopupView.Superview.Hidden = true;
                            //SetUpUserHand();
                            
                            gameRoundWinnerResult = await gameManager.GetWinner(roundNo,GameEnums.GetTableType(UsrManager.CurrentUser.SelectedTableType),UsrManager.CurrentUser.SelectedHand);
                            if(gameRoundWinnerResult != null)
                            {
                                this.BindData(gameRoundWinnerResult, UsrManager.CurrentUser.SelectedTableType);
                            }
                            setupRanks(roundNo);
                            roundNo++;
                            StartGamePlay(superView);

                        });

                    }
                });
            }
        }
        private void setupRanks(int winnerId)
        {
            //check if the current user is winner then 
            if (winnerId != 0)
            {
                switch (winnerId)
                {
                    case 1:
                        playerView_1.ShowWinnerRank("1st");

                        break;
                    case 2:
                        playerView_2.ShowWinnerRank("2nd");
                        break;
                    case 3:
                        if (UsrManager.CurrentUser.SelectedTableType > 3)
                        {
                            playerView_3.ShowWinnerRank("3rd");
                        }

                        break;
                    case 4:
                        if (UsrManager.CurrentUser.SelectedTableType > 4)
                        {
                            playerView_4.ShowWinnerRank("4th");
                        }
                        break;
                    default:
                        break;

                }
            }
        }
        private void SetUpUserHand()
        {
            handImg1.Image = UIImage.FromBundle(CommonMethods.GetHandImage(UsrManager.CurrentUser.SelectedHand));
        }
        private void SetupPlayerProfile()
        {
            
        }
        private void setupHands()
        {
            handImg1.Hidden = handImg2.Hidden = handImg3.Hidden = handImg4.Hidden = handImg5.Hidden = true;
            handImg1.Image = handImg2.Image = handImg3.Image = handImg4.Image = handImg5.Image = null;
            handImg1.Transform = CGAffineTransform.MakeRotation((nfloat)(Math.PI / (1 / (180f / 180f))));
            handImg2.Transform = CGAffineTransform.MakeRotation((nfloat)(Math.PI / (1 / (90f / 180f))));
            handImg3.Transform = CGAffineTransform.MakeRotation(-(nfloat)(Math.PI / (1 / (90f / 180f))));
            handImg4.Transform = CGAffineTransform.MakeRotation((nfloat)(Math.PI / (1 / (45f / 180f))));
            handImg5.Transform = CGAffineTransform.MakeRotation(-(nfloat)(Math.PI / (1 / (45f / 180f))));
        }
        public void setupPlayerView(int numberOfPlayers)
        {
            UsrManager.CurrentUser.SelectedTableType = numberOfPlayers;
            switch (numberOfPlayers)
            {
                case 5:
                    playerView_5 = PlayerView.Create();
                    playerView_5.Frame = new CGRect(0, 0, playerView5.Frame.Size.Width, playerView5.Frame.Size.Height);
                    playerView_5.setRankPosition(true);
                    playerView5.AddSubview(playerView_5);
                    handImg5.Hidden = false;
                    goto case 4;
                case 4:
                    playerView_4 = PlayerView.Create();
                    playerView_4.Frame = new CGRect(0, 0, playerView4.Frame.Size.Width, playerView4.Frame.Size.Height);
                    playerView_4.setRankPosition(false);
                    playerView4.AddSubview(playerView_4);
                    handImg4.Hidden = false;
                    goto case 3;
                case 3:
                    playerView_1 = PlayerView.Create();
                    playerView_1.Frame = new CGRect(0, 0, playerView1.Frame.Size.Width, playerView1.Frame.Size.Height);
                    playerView_1.setRankPosition(true);
                    //playerView_1.BindData(UsrManager.CurrentUser.Profile.UsrName, UsrManager.CurrentUser.GetFavoriteHand().Title);
                    //handImg1.Image = UIImage.FromBundle(CommonMethods.GetHandImage(UsrManager.CurrentUser.GetFavoriteHand().Id));
                    playerView1.AddSubview(playerView_1);
                    handImg1.Hidden = false;

                    playerView_2 = PlayerView.Create();
                    playerView_2.Frame = new CGRect(0, 0, playerView2.Frame.Size.Width, playerView2.Frame.Size.Height);
                    playerView_2.setRankPosition(false);
                    playerView2.AddSubview(playerView_2);
                    handImg2.Hidden = false;

                    playerView_3 = PlayerView.Create();
                    playerView_3.Frame = new CGRect(0, 0, playerView3.Frame.Size.Width, playerView3.Frame.Size.Height);
                    playerView_3.setRankPosition(true);
                    playerView3.AddSubview(playerView_3);
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
                case 5:
                    playerScoreView = PlayerScoreView.Create();
                    playerScoreView.Frame = new CGRect(0, 0, playerScoreView5.Frame.Size.Width, playerScoreView5.Frame.Size.Height);
                    playerScoreView.getPlayerBgView().BackgroundColor = ColorConstants.PlayerScoreView.playerBg5;
                    playerScoreView5.AddSubview(playerScoreView);
                    goto case 4;
                case 4:
                    playerScoreView = PlayerScoreView.Create();
                    playerScoreView.Frame = new CGRect(0, 0, playerScoreView4.Frame.Size.Width, playerScoreView4.Frame.Size.Height);
                    playerScoreView.getPlayerBgView().BackgroundColor = ColorConstants.PlayerScoreView.playerBg4;
                    playerScoreView4.AddSubview(playerScoreView);
                    goto case 3;
                case 3:
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
        public void BindData(GameRoundWinnerResult gameRoundWinnerResult, int numberOfPlayers)
        {
            GameTable gameTable = gameRoundWinnerResult.gameTable;
            switch (numberOfPlayers)
            {
                case 5:
                    handImg5.Image = UIImage.FromBundle(CommonMethods.GetHandImage(gameTable.Player5Symbol));
                    
                    handImg5.Hidden = false;
                    goto case 4;
                case 4:

                    handImg4.Image = UIImage.FromBundle(CommonMethods.GetHandImage(gameTable.Player4Symbol));
                    handImg4.Hidden = false;
                    goto case 3;
                case 3:
                    playerView_1.BindData(UsrManager.CurrentUser.Profile.UsrName, UsrManager.CurrentUser.GetFavoriteHand().Title);
                    handImg1.Image = UIImage.FromBundle(CommonMethods.GetHandImage(UsrManager.CurrentUser.SelectedHand));
                    handImg1.Hidden = false;

                    handImg2.Image = UIImage.FromBundle(CommonMethods.GetHandImage(gameTable.Player2Symbol));
                    handImg2.Hidden = false;

                    handImg3.Image = UIImage.FromBundle(CommonMethods.GetHandImage(gameTable.Player3Symbol));
                    handImg3.Hidden = false;
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