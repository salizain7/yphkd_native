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
    [Register ("PlayerView")]
    partial class PlayerView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel playerHand { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView playerImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel playerName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (playerHand != null) {
                playerHand.Dispose ();
                playerHand = null;
            }

            if (playerImg != null) {
                playerImg.Dispose ();
                playerImg = null;
            }

            if (playerName != null) {
                playerName.Dispose ();
                playerName = null;
            }
        }
    }
}