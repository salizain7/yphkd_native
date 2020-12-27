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
	[Register ("BasePopupView")]
	partial class BasePopupView
	{
		[Outlet]
		UIKit.UIButton bottomBtn { get; set; }

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
			if (bottomBtn != null) {
				bottomBtn.Dispose ();
				bottomBtn = null;
			}

			if (centerView != null) {
				centerView.Dispose ();
				centerView = null;
			}

			if (mainView != null) {
				mainView.Dispose ();
				mainView = null;
			}

			if (popupBtn != null) {
				popupBtn.Dispose ();
				popupBtn = null;
			}

			if (titleLbl != null) {
				titleLbl.Dispose ();
				titleLbl = null;
			}
		}
	}
}
