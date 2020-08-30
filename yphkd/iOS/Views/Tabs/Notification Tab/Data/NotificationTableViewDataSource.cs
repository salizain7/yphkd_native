using System;
using Foundation;
using UIKit;
using yphkd.iOS.Views.Tabs.NotificationTab.Cell;

namespace yphkd.iOS.Views.Tabs.NotificationTab.Data
{
    public class NotificationTableViewDataSource : UITableViewDataSource
    {
        public NotificationTableViewDataSource()
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            NotificationsTableViewCell Cell = tableView.DequeueReusableCell(NotificationsTableViewCell.Key, indexPath) as NotificationsTableViewCell;
            Cell.BindData("Ali accepted your challenge " + ((int)indexPath.Row + 1) );

            return Cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return 10;
        }
    }
}
