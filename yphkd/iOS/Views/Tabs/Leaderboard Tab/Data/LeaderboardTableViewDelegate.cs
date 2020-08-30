using System;
using Foundation;
using UIKit;


namespace yphkd.iOS.Views.Tabs.LeaderboardTab.Data
{
    public class LeaderboardTableViewDelegate : UITableViewDelegate
    {
        public LeaderboardTableViewDelegate()
        {
        }
        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return tableView.Frame.Height / 7;
        }
    }
}
