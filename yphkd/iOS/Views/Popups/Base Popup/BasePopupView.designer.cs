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
    [Register ("BasePopupView")]
    partial class BasePopupView
    {
        [Outlet]
        UIKit.UIButton bottomBtn { get; set; }


        [Outlet]
        UIKit.UIView bottomView { get; set; }


        [Outlet]
        UIKit.UIView centerView { get; set; }


        [Outlet]
        UIKit.UIView mainView { get; set; }


        [Outlet]
        UIKit.UIButton popupBtn { get; set; }


        [Outlet]
        UIKit.UILabel titleLbl { get; set; }


        [Action ("onClickBottomBtn:")]
        partial void onClickBottomBtn (UIKit.UIButton sender);


        [Action ("onclickPopupBtn:")]
        partial void onclickPopupBtn (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
        }
    }
}