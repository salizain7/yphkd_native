using Foundation;
using System;
using UIKit;
using yphkd.iOS.Views.Tabs.FriendsTab.Cell;
using yphkd.iOS.Views.Tabs.FriendsTab.Data;

namespace yphkd.iOS
{
    public partial class FriendsTabView : UIView
    {
        public FriendsTabView (IntPtr handle) : base (handle)
        {
        }
        public static FriendsTabView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("FriendsTabView", null, null);
            var v = arr.GetItem<FriendsTabView>(0);
            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            setupTableView();
        }
        public void setupTableView()
        {
            friendsTableView.RegisterNibForCellReuse(UINib.FromName(FriendsTableViewCell.Key, null), FriendsTableViewCell.Key);

            friendsTableView.DataSource = new FriendsTableViewDataSource();
            friendsTableView.Delegate = new FriendsTableViewDelegate();
        }


    }
}