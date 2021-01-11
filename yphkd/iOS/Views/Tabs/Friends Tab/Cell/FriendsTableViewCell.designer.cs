// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace yphkd.iOS.Views.Tabs.FriendsTab.Cell
{
    [Register ("FriendsTableViewCell")]
    partial class FriendsTableViewCell
    {
        [Outlet]
        UIKit.UIView cellView { get; set; }

        [Outlet]
        UIKit.UIImageView profileImg { get; set; }


        [Outlet]
        UIKit.UIView shadeView { get; set; }


        [Outlet]
        UIKit.UILabel usrnameLbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton inviteBtn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (inviteBtn != null) {
                inviteBtn.Dispose ();
                inviteBtn = null;
            }
        }
    }
}