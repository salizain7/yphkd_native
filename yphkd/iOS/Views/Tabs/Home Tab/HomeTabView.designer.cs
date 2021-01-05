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
    [Register ("HomeTabView")]
    partial class HomeTabView
    {
        [Outlet]
        UIKit.UIImageView centerLogoImg { get; set; }


        [Outlet]
        UIKit.UIView favHandBgView { get; set; }


        [Outlet]
        UIKit.UIView favHandIconBgView { get; set; }


        [Outlet]
        UIKit.UIImageView favHandIconImg { get; set; }


        [Outlet]
        UIKit.UILabel favHandLbl { get; set; }


        [Outlet]
        UIKit.UIButton letsPlayBtn { get; set; }


        [Outlet]
        UIKit.UIView letsPlayOutterBgView { get; set; }


        [Outlet]
        UIKit.UIView loginIconBgView { get; set; }


        [Outlet]
        UIKit.UIImageView loginIconImg { get; set; }


        [Outlet]
        UIKit.UILabel loginLbl { get; set; }


        [Outlet]
        UIKit.UIView loginLblBgView { get; set; }


        [Outlet]
        UIKit.UIButton pwfBtn { get; set; }


        [Outlet]
        UIKit.UIView pwfOutterBgView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView bellIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel notiCountLbl { get; set; }


        [Action ("onClickLetsPlayBtn:")]
        partial void onClickLetsPlayBtn (UIKit.UIButton sender);


        [Action ("onClickPwfBtn:")]
        partial void onClickPwfBtn (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (bellIcon != null) {
                bellIcon.Dispose ();
                bellIcon = null;
            }

            if (notiCountLbl != null) {
                notiCountLbl.Dispose ();
                notiCountLbl = null;
            }
        }
    }
}