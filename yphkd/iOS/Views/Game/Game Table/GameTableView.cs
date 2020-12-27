using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using yphkd.Facade;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;
using yphkd.iOS.Managers;
using yphkd.Model.Game;
using yphkd.Model.GameDefinition;
using yphkd.Model.ServerResults;
using yphkd.Users;

namespace yphkd.iOS
{
    public partial class GameTableView : UIView
    {

        //uiview classes
        PlayerView[] playerViews = new PlayerView[5];
        PlayerScoreView[] playerScoreViews = new PlayerScoreView[5];

        //uiviews 
        UIView[] playerUIViews = new UIView[5];
        UIView[] playerScoreUIViews = new UIView[5];
        UIImageView[] playerHandImages = new UIImageView[5];

        //profile data from userplayrequest api
        List<UsrProfile> playerProfiles = new List<UsrProfile>();

        
        UIViewController rootController;
        BasePopupView basePopupView;


        UserPlayRequestResult usrPlayReqResult = new UserPlayRequestResult();
        GameRoundWinnerResult gameRoundWinnerResult = new GameRoundWinnerResult();

        int roundNo = 1;
        public static WaitPlayersPopup waitPlayerPopup;

        public GameTableView(IntPtr handle) : base(handle)
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

            

            playerUIViews = new UIView[] { playerView1, playerView2, playerView3, playerView4,playerView5};
            playerScoreUIViews = new UIView[] { playerScoreView1, playerScoreView2, playerScoreView3, playerScoreView4, playerScoreView5 };

            playerHandImages = new UIImageView[] {handImg1, handImg2, handImg3, handImg4, handImg5 };

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
                        if (usrPlayReqResult != null)
                        {
                            this.SetPlayersProfile(usrPlayReqResult, UsrManager.CurrentUser.SelectedTableType);
                        }
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
            if (roundNo < UsrManager.CurrentUser.SelectedTableType)
            {
                NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, 3), delegate
                {
                    roundNoLbl.Text = "Round " + roundNo;
                });
                AnimationManager.Zoom(roundNoLbl, true, 0.8, onFinished: () =>
                {
                    NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, 5), delegate
                    {
                        showSelectHandPopup(popupView);
                    });
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
            basePopupView.showSelectHandPopup(rootController, "SELECT ANY HAND", "", false, handId: UsrManager.CurrentUser.GetFavoriteHand().Id);
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
                        //basePopupView.setBtnTitle("Time: " + TimeLeft.ToString());

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

                            gameRoundWinnerResult = await gameManager.GetWinner(roundNo, GameEnums.GetTableType(UsrManager.CurrentUser.SelectedTableType), UsrManager.CurrentUser.SelectedHand);
                            if (gameRoundWinnerResult != null)
                            {
                                this.ShowPlayersSelectedHands(gameRoundWinnerResult, UsrManager.CurrentUser.SelectedTableType, superView);
                            }
                            NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, 3), delegate
                            {
                                setupRanks(roundNo);
                                roundNo++;
                            });


                            //NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, 5), delegate
                            //{
                            //    StartGamePlay(superView);
                            //});

                        });

                    }
                });
            }
        }
        private void setupRanks(int winnerId)
        {
            //check if the current user is winner then

            
            if (winnerId != 0 && winnerId <= playerViews.Length)
            {
                playerViews[winnerId - 1].ShowWinnerRank(winnerId.ToString());
                
            }

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

            for (int i = 0; i < numberOfPlayers; i++)
            {
                playerViews[i] = PlayerView.Create();
                playerViews[i].Frame = new CGRect(0, 0, playerUIViews[i].Frame.Size.Width, playerUIViews[i].Frame.Size.Height);
                playerViews[i].setRankPosition(i%2 != 0);
                playerUIViews[i].AddSubview(playerViews[i]);
                playerHandImages[i].Hidden = false;
            }
            
        }


        public void setupPlayerScoreView(int numberOfPlayers)
        {

            for (int i = 0; i < numberOfPlayers; i++)
            {
                playerScoreViews[i] = PlayerScoreView.Create();
                playerScoreViews[i].Frame = new CGRect(0, 0, playerScoreUIViews[i].Frame.Size.Width, playerScoreUIViews[i].Frame.Size.Height);
                playerScoreViews[i].getPlayerBgView().BackgroundColor = ColorConstants.PlayerScoreView.playersColors[i];
                playerScoreUIViews[i].AddSubview(playerScoreViews[i]);
            }

        }
        private void SetPlayersProfile(UserPlayRequestResult userPlayReqResult, int numberOfPlayers)
        {
            playerProfiles.Add(userPlayReqResult.usrProfile_1);
            playerProfiles.Add(userPlayReqResult.usrProfile_2);
            playerProfiles.Add(userPlayReqResult.usrProfile_3);
            playerProfiles.Add(userPlayReqResult.usrProfile_4);
            playerProfiles.Add(userPlayReqResult.usrProfile_5);


            for (int i = 0; i < numberOfPlayers; i++)
            {
                playerViews[i].BindData(playerProfiles[i].UsrName,
                        Enum.GetName(typeof(GameEnums.HandEnum), Int32.Parse(playerProfiles[i].UsrSymbol)),
                        playerProfiles[i].UsrImg);
                playerScoreViews[i].BindData(
                    Enum.GetName(typeof(GameEnums.HandEnum), Int32.Parse(playerProfiles[i].UsrSymbol)),
                    playerProfiles[i].UsrCoins.ToString(),
                    playerProfiles[i].UsrImg
                    );
            }

            
        }
        public void ShowPlayersSelectedHands(GameRoundWinnerResult gameRoundWinnerResult, int numberOfPlayers, UIView popupView)
        {
            GameTable gameTable = gameRoundWinnerResult.gameTable;

            List<int> playersFavSymbols = new List<int>();
            playersFavSymbols.Add(gameTable.Player1Symbol);
            playersFavSymbols.Add(gameTable.Player2Symbol);
            playersFavSymbols.Add(gameTable.Player3Symbol);
            playersFavSymbols.Add(gameTable.Player4Symbol);
            playersFavSymbols.Add(gameTable.Player5Symbol);

            for (int i = 0; i < numberOfPlayers; i++)
            {
                playerHandImages[i].Hidden = false;
                playerHandImages[i].Image = UIImage.FromBundle(CommonMethods.GetHandImage(playersFavSymbols[i]));
            }

            if(UsrManager.CurrentUser.Guid == gameRoundWinnerResult.winnerProfile.Guid)
            {
                //show winner popup
                showWinnerPopup(popupView);
            }
            else
            {
                //show looser popup
                showLooserPopup(popupView);
            }

        }
        private void showWinnerPopup(UIView popupView)
        {
            popupView.Hidden = false;
            CommonMethods.clearView(popupView);
            popupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);

            basePopupView = BasePopupView.Create();
            //basePopupView.showLooserPopup(rootController, "Sorry you didn't win this round", "Continue", true);
            basePopupView.showWinnerPopup(rootController, "Winner of Round " + roundNo, "Home", true);
            //basePopupView.showWinnerPopup(RootViewController, "Sorry !\n Better luck next time", "Home", true);
            basePopupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, popupView.Frame.Height);

            this.BringSubviewToFront(popupView);

            CommonMethods.SetUpBlurBackground(popupView);
            NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, 5), delegate
            {
                
            });
            AnimationManager.Fade(popupView, true, onFinished: () =>
            {
                popupView.AddSubview(basePopupView);
                NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, 0), delegate
                {
                    StartGamePlay(popupView);
                });
            });
        }
        private void showLooserPopup(UIView popupView)
        {
            popupView.Hidden = false;
            CommonMethods.clearView(popupView);
            popupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);

            basePopupView = BasePopupView.Create();
            basePopupView.showLooserPopup(rootController, "Sorry you didn't win this round", "Continue", true);
            //basePopupView.showWinnerPopup(RootViewController, "Winner of Round 1", "Home", true);
            //basePopupView.showWinnerPopup(RootViewController, "Sorry !\n Better luck next time", "Home", true);
            basePopupView.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, popupView.Frame.Height);

            this.BringSubviewToFront(popupView);

            CommonMethods.SetUpBlurBackground(popupView);
            NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, 5), delegate
            {

            });
            AnimationManager.Fade(popupView, true, onFinished: () =>
            {
                popupView.AddSubview(basePopupView);
                NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, 0), delegate
                {
                    StartGamePlay(popupView);
                });
            });
        }
        partial void onClickBackBtn(UIButton sender)
        {
            if (rootController != null)
            {
                var homeViewcontroller = rootController as HomeViewController;
                AnimationManager.Fade(this, false, onFinished: () =>
                {
                    homeViewcontroller.getBottomView().showAdView(false);

                    homeViewcontroller.getBottomView().showHomeTab();

                });
            }
        }
    }
}