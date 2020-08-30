using System;
using Foundation;
using UIKit;
using yphkd.iOS.ViewControllers.Tutorial.Cell;

namespace yphkd.iOS.ViewControllers.Tutorial.Data
{
    public class TutorialCollectionViewDataSource : UICollectionViewDataSource
    {
        public TutorialCollectionViewDataSource()
        {
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            TutorialCollectionViewCell Cell = collectionView.DequeueReusableCell(TutorialCollectionViewCell.Key, indexPath) as TutorialCollectionViewCell;
            Cell.setupTutorial(indexPath.Row);
            return Cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 2 ;
        }
    }
}
