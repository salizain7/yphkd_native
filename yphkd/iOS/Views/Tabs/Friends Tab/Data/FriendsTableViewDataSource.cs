using System;
using Foundation;
using UIKit;
using yphkd.iOS.Views.Tabs.FriendsTab.Cell;

namespace yphkd.iOS.Views.Tabs.FriendsTab.Data
{
    public class FriendsTableViewDataSource: UITableViewDataSource
    {
        public FriendsTableViewDataSource()
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            FriendsTableViewCell Cell = tableView.DequeueReusableCell(FriendsTableViewCell.Key, indexPath) as FriendsTableViewCell;
            Cell.BindData( "Ali Zain" + " " + (indexPath.Row).ToString(), (indexPath.Row * 10000).ToString(), (int)indexPath.Row);


            return Cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return 10;
        }
    }
}
