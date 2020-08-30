using System;
using Foundation;
using UIKit;

namespace yphkd.iOS.Views.Tabs.NotificationTab.Data
{
    public class NotificationTableViewDelegate : UITableViewDelegate
    {
        public NotificationTableViewDelegate()
        {
        }
        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return tableView.Frame.Height / 7;
        }
    }
}
