using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace yphkd.iOS.ViewControllers.Tutorial.Data
{
    public class TutorialCollectionViewDelegate : UICollectionViewDelegateFlowLayout
    {
        public TutorialCollectionViewDelegate()
        {
        }
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(collectionView.Frame.Width, collectionView.Frame.Height);
        }
    }
}
