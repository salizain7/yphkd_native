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
        int screen = 0;
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
            
        }
        public void setBanner(int screenNo)
        {
            screen = screenNo;
            setupView();
        }
        private void setupView()
        {
            if(screen==1)
                headerBgImg.Image = UIImage.FromBundle(ImageConstants.Dialogue.headerImgBundle);
            else if(screen==2)
                headerBgImg.Image = UIImage.FromBundle(ImageConstants.Dialogue.headerImgFriend);
            else if(screen ==3)
                headerBgImg.Image = UIImage.FromBundle(ImageConstants.Dialogue.headerImgLeaderboard);

        }

        public UIView getCenterView()
        {
            return centerView;
        }

       
        //partial void onClickInviteBtn(UIButton sender)
        //{
        //    if (isFromFriends)
        //    {

        //    }
        //}
    }
}