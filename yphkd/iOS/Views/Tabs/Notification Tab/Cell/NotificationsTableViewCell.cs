using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;

namespace yphkd.iOS.Views.Tabs.NotificationTab.Cell
{
    public partial class NotificationsTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("NotificationsTableViewCell");
        public static readonly UINib Nib;

        CAGradientLayer gradLayer = new CAGradientLayer();

        static NotificationsTableViewCell()
        {
            Nib = UINib.FromName("NotificationsTableViewCell", NSBundle.MainBundle);
        }

        protected NotificationsTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            setupView();
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            gradLayer.Frame = new CGRect(0, 0, cellView.Frame.Width, cellView.Frame.Height);
        }
        private void setupView()
        {
            notificationLbl.TextColor = UIColor.Black;


            gradLayer = CommonMethods.addGradient(cellView, ColorConstants.Friends.cellViewStartColorLive.CGColor,
                ColorConstants.Friends.cellViewEndColorLive.CGColor, false);
            cellView.Layer.BorderColor = ColorConstants.Friends.cellViewBorder.CGColor;
            cellView.Layer.BorderWidth = 1.7f;

            cellView.Layer.CornerRadius = 12;
            cellView.Layer.MasksToBounds = true;


            userImage.Image = UIImage.FromBundle(ImageConstants.Common.placeholder_img);


        }
        public void BindData(string text)
        {
            notificationLbl.Text = text;

        }
    }
}
