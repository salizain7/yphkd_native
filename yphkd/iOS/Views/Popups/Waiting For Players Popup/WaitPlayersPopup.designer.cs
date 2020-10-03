// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace yphkd.iOS
{
	[Register ("WaitPlayersPopup")]
	partial class WaitPlayersPopup
	{
		[Outlet]
		UIKit.UIView bottomView { get; set; }

		[Outlet]
		UIKit.UIView loaderBgView { get; set; }

		[Outlet]
		UIKit.UIImageView loaderImg { get; set; }

		[Outlet]
		UIKit.UILabel timerLbl { get; set; }

		[Outlet]
		UIKit.UILabel waitingLbl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (loaderBgView != null) {
				loaderBgView.Dispose ();
				loaderBgView = null;
			}

			if (loaderImg != null) {
				loaderImg.Dispose ();
				loaderImg = null;
			}

			if (bottomView != null) {
				bottomView.Dispose ();
				bottomView = null;
			}

			if (timerLbl != null) {
				timerLbl.Dispose ();
				timerLbl = null;
			}

			if (waitingLbl != null) {
				waitingLbl.Dispose ();
				waitingLbl = null;
			}
		}
	}
}
