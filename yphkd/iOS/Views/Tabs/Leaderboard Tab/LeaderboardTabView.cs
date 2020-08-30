using Foundation;
using System;
using UIKit;
using yphkd.iOS.Views.Tabs.FriendsTab.Cell;
using yphkd.iOS.Views.Tabs.LeaderboardTab.Data;

namespace yphkd.iOS
{
    public partial class LeaderboardTabView : UIView
    {
        public LeaderboardTabView (IntPtr handle) : base (handle)
        {
        }
        public static LeaderboardTabView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("LeaderboardTabView", null, null);
            var v = arr.GetItem<LeaderboardTabView>(0);


            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            setupTableView();
        }
        public void setupTableView()
        {
            leaderboardTableView.RegisterNibForCellReuse(UINib.FromName(FriendsTableViewCell.Key, null), FriendsTableViewCell.Key);

            leaderboardTableView.DataSource = new LeaderboardTableViewDataSource();
            leaderboardTableView.Delegate = new LeaderboardTableViewDelegate();
        }

    }
}