using System;
using Foundation;
using UIKit;

namespace yphkd.iOS.Views.Tabs.FriendsTab.Data
{
    public class FriendsTableViewDelegate : UITableViewDelegate
    {
        public FriendsTableViewDelegate()
        {
        }
        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return tableView.Frame.Height / 7;
        }
    }
}
