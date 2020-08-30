using System;

using Foundation;
using UIKit;
using yphkd.iOS.Constants;

namespace yphkd.iOS.Views.Tabs.ShopTab.Cell
{
    public partial class ShopTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ShopTableViewCell");
        public static readonly UINib Nib;

        static ShopTableViewCell()
        {
            Nib = UINib.FromName("ShopTableViewCell", NSBundle.MainBundle);
        }

        protected ShopTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            setupView();
        }
        private void setupView()
        {
            this.BackgroundColor = UIColor.Clear;
            cellView.BackgroundColor = ColorConstants.Shop.shopCellBg;
            cellView.Layer.CornerRadius = 14;
            cellView.Layer.BorderWidth = 4;
            cellView.Layer.BorderColor = ColorConstants.Shop.shopCellBorder.CGColor;

            priceBgView.BackgroundColor = ColorConstants.Shop.priceBg;
            priceBgView.Layer.CornerRadius = 8;
            priceBgView.Layer.BorderWidth = 2;
            priceBgView.Layer.BorderColor = UIColor.White.CGColor;

            amountLbl.TextColor = priceLbl.TextColor = UIColor.White;

            rewardImg.Image = UIImage.FromBundle(ImageConstants.Shop.coins_sack);
        }
        public void bindData(string rewardAmount, string price)
        {
            amountLbl.Text = rewardAmount;
            priceLbl.Text = price + " PKR";
        }
    }
}
