﻿using System;
using Foundation;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.ViewControllers.Tutorial.Cell;
using yphkd.iOS.ViewControllers.Tutorial.Data;

namespace yphkd.iOS.ViewControllers.Tutorial
{
    public partial class TutorialViewController : UIViewController
    {
       
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

            tutorialCollectionView.DataSource = new TutorialCollectionViewDataSource();
            tutorialCollectionView.Delegate = new TutorialCollectionViewDelegate();
            
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
                tutorialCollectionView.ScrollToItem(NSIndexPath.FromRowSection(1, 0), UICollectionViewScrollPosition.CenteredHorizontally, true);
            }
        }
    }
}
