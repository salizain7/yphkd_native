using Foundation;
using System;
using UIKit;
using yphkd.iOS.Views.Game.ModeSelection.SelectTableCollectionView.Cell;
using yphkd.iOS.Views.Game.ModeSelection.SelectTableCollectionView.Data;

namespace yphkd.iOS
{
    public partial class SelectTableCollectionView : UIView
    {
        UIViewController rootController;
        public SelectTableCollectionView (IntPtr handle) : base (handle)
        {
        }
        public static SelectTableCollectionView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("SelectTableCollectionView", null, null);
            var v = arr.GetItem<SelectTableCollectionView>(0);
            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }
        public void setCollectionView(UIViewController controller)
        {
            rootController = controller;
            collectionView.RegisterNibForCell(UINib.FromName(SelectTableCollectionViewCell.Key, null), SelectTableCollectionViewCell.Key);

            collectionView.DataSource = new SelectTableCVDataSource();
            collectionView.Delegate = new SelectTableCVDelegate(rootController);
            collectionView.ScrollEnabled = false;
            //collectionView.BackgroundColor = UIColor.White;
        }
    }
}