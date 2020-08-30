using Foundation;
using System;
using UIKit;
using yphkd.iOS.Views.Tabs.ShopTab.Cell;
using yphkd.iOS.Views.Tabs.ShopTab.Data;

namespace yphkd.iOS
{
    public partial class ShopTabView : UIView
    {
        public ShopTabView (IntPtr handle) : base (handle)
        {
        }
        public static ShopTabView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("ShopTabView", null, null);
            var v = arr.GetItem<ShopTabView>(0);


            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            setupTableView();
        }
        public void setupTableView()
        {
            shopTableView.RegisterNibForCellReuse(UINib.FromName(ShopTableViewCell.Key, null), ShopTableViewCell.Key);

            shopTableView.DataSource = new ShopTableViewDataSource();
            shopTableView.Delegate = new ShopTableViewDelegate();
        }
    }
}