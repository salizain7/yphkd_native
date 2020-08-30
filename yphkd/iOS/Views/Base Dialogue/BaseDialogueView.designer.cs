// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace yphkd.iOS
{
    [Register ("BaseDialogueView")]
    partial class BaseDialogueView
    {
        [Outlet]
        UIKit.UIView centerView { get; set; }


        [Outlet]
        UIKit.UIImageView headerBgImg { get; set; }


        [Outlet]
        UIKit.UIButton inviteBtn { get; set; }


        [Outlet]
        UIKit.UIView inviteButtonBgView { get; set; }


        [Outlet]
        UIKit.UIView mainBgView { get; set; }


        [Outlet]
        UIKit.UILabel titleLabel { get; set; }


        [Action ("onClickInviteBtn:")]
        partial void onClickInviteBtn (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
        }
    }
}