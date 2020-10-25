using System;
using System.Reflection;
using Foundation;
using UIKit;
using yphkd.Facade;
using yphkd.iOS.Common;
using yphkd.iOS.ViewControllers.Tutorial.Cell;
using yphkd.iOS.ViewControllers.Tutorial.Data;
using yphkd.Users;

namespace yphkd.iOS.ViewControllers.Tutorial
{
    public partial class TutorialViewController : UIViewController
    {

        public bool handIsSelected { get; set; } = false;
        public int selectedHand { get; set; } = 0;

        public TutorialViewController() : base("TutorialViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            setCollectionView();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        public void setCollectionView()
        {
            tutorialCollectionView.RegisterNibForCell(UINib.FromName(TutorialCollectionViewCell.Key, null), TutorialCollectionViewCell.Key);

            tutorialCollectionView.DataSource = new TutorialCollectionViewDataSource(this);
            tutorialCollectionView.Delegate = new TutorialCollectionViewDelegate(this);
            
        }
        public void EnableContinueBtn(bool flag)
        {
            continueBtn.Enabled = flag;
            continueBtn.Hidden = !flag;
        }
        
        partial void onClickContinue(UIButton sender)
        {
            if(tutorialCollectionView.IndexPathForCell(tutorialCollectionView.VisibleCells[0]).Row == 1)
            {
                InvokeOnMainThread(() =>
                {
                    CommonMethods.SetupHomeScreen();
                });
            } else
            {
                
                BeginInvokeOnMainThread(() =>
                {
                    
                    tutorialCollectionView.ScrollToItem(NSIndexPath.FromRowSection(1, 0), UICollectionViewScrollPosition.CenteredHorizontally, true);
                    //tutorialCollectionView.ReloadData();
                });
                
            }
        }
        public void SaveHandAsFavourite(int handId)
        {
            try
            {
                
                UsrContent uc = new UsrContent();
                uc.UsrId = UsrManager.CurrentUser.Guid;
                
                uc.ContentId = handId;
                uc.SetAsFavorite();
                
                UsrManager.CurrentUser.SetFavHand(uc);
                UsrManager.CurrentUser.SaveToPreferences();
               
            }
            catch (Exception ex)
            {
                Utils.TrackErrors(MethodBase.GetCurrentMethod(), ex);
            }
        }
    }
}

