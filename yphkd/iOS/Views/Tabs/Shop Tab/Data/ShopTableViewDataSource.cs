using System;
using CoreGraphics;
using Foundation;
using UIKit;
using yphkd.iOS.Views.Tabs.ShopTab.Cell;

namespace yphkd.iOS.Views.Tabs.ShopTab.Data
{
    public class ShopTableViewDataSource: UITableViewDataSource
    {
        public ShopTableViewDataSource()
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            ShopTableViewCell Cell = tableView.DequeueReusableCell(ShopTableViewCell.Key, indexPath) as ShopTableViewCell;
            Cell.bindData((indexPath.Row * 10).ToString(), (indexPath.Row * 1).ToString());
            
            
            return Cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return 8;
        }

    }
}
