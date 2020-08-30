using System;
using Foundation;
using UIKit;

namespace yphkd.iOS.Views.Tabs.ShopTab.Data
{
    public class ShopTableViewDelegate: UITableViewDelegate
    {
        public ShopTableViewDelegate()
        {
        }
        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return tableView.Frame.Height / 5;
        }
        

    }
}
