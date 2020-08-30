using Foundation;
using System;
using UIKit;
using yphkd.iOS.Views.Tabs.NotificationTab.Cell;
using yphkd.iOS.Views.Tabs.NotificationTab.Data;

namespace yphkd.iOS
{
    public partial class NotificationTabView : UIView
    {
        public NotificationTabView (IntPtr handle) : base (handle)
        {
        }
        public static NotificationTabView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("NotificationTabView", null, null);
            var v = arr.GetItem<NotificationTabView>(0);


            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            setupTableView();
        }
        public void setupTableView()
        {
            notificationsTableView.RegisterNibForCellReuse(UINib.FromName(NotificationsTableViewCell.Key, null), NotificationsTableViewCell.Key);

            notificationsTableView.DataSource = new NotificationTableViewDataSource();
            notificationsTableView.Delegate = new NotificationTableViewDelegate();
        }
    }
}