using System;
using Foundation;
using UIKit;
using yphkd.iOS.Constants;
using yphkd.iOS.Views.Game.ModeSelection.SelectTableCollectionView.Cell;

namespace yphkd.iOS.Views.Game.ModeSelection.SelectTableCollectionView.Data
{
    public class SelectTableCVDataSource: UICollectionViewDataSource
    {
        int count = 1;
        public SelectTableCVDataSource()
        {
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {

            SelectTableCollectionViewCell Cell = collectionView.DequeueReusableCell(SelectTableCollectionViewCell.Key, indexPath) as SelectTableCollectionViewCell;
            
            Cell.BindData(((count * 100) + 200).ToString() + " COINS", ImageConstants.TableType.table_images[indexPath.Row]);
            Cell.setViewTag(count + 2);
            if(indexPath.Row == 0)
            {
                //Cell.SetSelected();
            }
            else if(indexPath.Row == 2)
            {
                Cell.SetUnSelectable();
            }
            
            count++;
            return Cell;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            //if(section == 0)
            //{
            //    return 2;
            //} else
            //{
            //    return 1;
            //}
            return 3;
        }
        
    }
}
