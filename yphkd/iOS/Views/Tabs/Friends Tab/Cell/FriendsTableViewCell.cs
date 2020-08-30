using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;

namespace yphkd.iOS.Views.Tabs.FriendsTab.Cell
{
    public partial class FriendsTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("FriendsTableViewCell");
        public static readonly UINib Nib;

        CAGradientLayer gradLayer = new CAGradientLayer();

        static FriendsTableViewCell()
        {
            Nib = UINib.FromName("FriendsTableViewCell", NSBundle.MainBundle);
        }

        protected FriendsTableViewCell(IntPtr handle) : base(handle)
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
            gradLayer.Frame = new CGRect(0,0,cellView.Frame.Width, cellView.Frame.Height);
        }
        private void setupView()
        {
            usrnameLbl.TextColor = UIColor.White;
            shadeView.BackgroundColor = UIColor.Clear;

            pointsLbl.TextColor = ColorConstants.Friends.pointsLbl;

            gradLayer = CommonMethods.addGradient(cellView, ColorConstants.Friends.cellViewStartColor.CGColor,
                ColorConstants.Friends.cellViewEndColor.CGColor, false);
            cellView.Layer.BorderColor = ColorConstants.Friends.cellViewBorder.CGColor;
            cellView.Layer.BorderWidth = 1.7f;

            cellView.Layer.CornerRadius = 12;
            cellView.Layer.MasksToBounds = true;


            liveStatusView.BackgroundColor = UIColor.Clear;
            CommonMethods.makeRoundCircle(liveStatusView);

            profileImg.Image = UIImage.FromBundle(ImageConstants.Common.placeholder_img);
            

        }
        public void BindData(string username, string usrPoints, int index)
        {
            switch (index)
            {
                case 0:
                    medalImg.Image = UIImage.FromBundle(ImageConstants.Friends.medal_1);
                    setupLiveView();
                    break;
                case 1:
                    medalImg.Image = UIImage.FromBundle(ImageConstants.Friends.medal_2);
                    break;
                case 2:
                    medalImg.Image = UIImage.FromBundle(ImageConstants.Friends.medal_3);
                    break;
            }
            usrnameLbl.Text = username;
            pointsLbl.Text = usrPoints;

        }
        public void setupLiveView()
        {
            cellView.Layer.Sublayers[0].RemoveFromSuperLayer();
            gradLayer = CommonMethods.addGradient(cellView, ColorConstants.Friends.cellViewStartColorLive.CGColor,
                ColorConstants.Friends.cellViewEndColorLive.CGColor, false);
            cellView.Layer.BorderColor = ColorConstants.Friends.cellViewBorderLive.CGColor;

            liveStatusView.Layer.BorderWidth = 1;
            liveStatusView.Layer.BorderColor = ColorConstants.Friends.liveStatusBorder.CGColor;

            liveStatusView.BackgroundColor = ColorConstants.Friends.liveStatus;


        }
    }
}
