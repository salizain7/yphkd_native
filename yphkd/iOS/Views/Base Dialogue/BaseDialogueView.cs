using Foundation;
using System;
using UIKit;
using yphkd.iOS.Common;
using yphkd.iOS.Constants;

namespace yphkd.iOS
{
    public partial class BaseDialogueView : UIView
    {
        bool isFromFriends = false;
        public BaseDialogueView (IntPtr handle) : base (handle)
        {
        }
        public static BaseDialogueView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("BaseDialogueView", null, null);
            var v = arr.GetItem<BaseDialogueView>(0);


            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            
            setupView();
        }

        public void setTitleLabel(string text)
        {
            titleLabel.Text = text;
        }
        private void setupView()
        {
            headerBgImg.Image = UIImage.FromBundle(ImageConstants.Dialogue.headerImg);
            headerBgImg.ContentMode = UIViewContentMode.ScaleToFill;

            //titleLabel.TextColor = UIColor.White;


            mainBgView.BackgroundColor = ColorConstants.BaseDialogue.centerViewBg;
            mainBgView.Layer.BorderColor = ColorConstants.BaseDialogue.centerViewBorder.CGColor;

            mainBgView.Layer.CornerRadius = 12;
            mainBgView.Layer.BorderWidth = 8;

            titleLabel.TextColor = UIColor.White;

            inviteButtonBgView.Layer.BorderColor = ColorConstants.Dialogue.buttomViewBorder.CGColor;
            CommonMethods.addGradient(inviteButtonBgView, ColorConstants.Dialogue.buttomBgStartColor.CGColor,
                ColorConstants.Dialogue.buttomBgEndColor.CGColor, false);
            inviteButtonBgView.Layer.BorderWidth = 2;
            inviteButtonBgView.Layer.CornerRadius = 14;
            inviteButtonBgView.Layer.MasksToBounds = true;

        }
        public UIView getCenterView()
        {
            return centerView;
        }
        public void hideBottomBtnView(bool flag, bool isFromFrnds = false)
        {
            inviteBtn.Hidden = inviteButtonBgView.Hidden = flag;
            inviteBtn.UserInteractionEnabled = !flag;
            isFromFriends = isFromFrnds;
            if (isFromFriends)
            {
                inviteBtn.SetTitle("Invite Friend", UIControlState.Normal);
                inviteBtn.SetTitleColor(UIColor.White, UIControlState.Normal);
            }
        }
        partial void onClickInviteBtn(UIButton sender)
        {
            if (isFromFriends)
            {

            }
        }
    }
}