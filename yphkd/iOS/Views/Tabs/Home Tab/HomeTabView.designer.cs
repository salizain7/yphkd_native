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

		[Action ("onClickLetsPlayBtn:")]
		partial void onClickLetsPlayBtn (UIKit.UIButton sender);

		[Action ("onClickPwfBtn:")]
		partial void onClickPwfBtn (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (centerLogoImg != null) {
				centerLogoImg.Dispose ();
				centerLogoImg = null;
			}

			if (favHandBgView != null) {
				favHandBgView.Dispose ();
				favHandBgView = null;
			}

			if (favHandIconBgView != null) {
				favHandIconBgView.Dispose ();
				favHandIconBgView = null;
			}

			if (favHandIconImg != null) {
				favHandIconImg.Dispose ();
				favHandIconImg = null;
			}

			if (favHandLbl != null) {
				favHandLbl.Dispose ();
				favHandLbl = null;
			}

			if (letsPlayBtn != null) {
				letsPlayBtn.Dispose ();
				letsPlayBtn = null;
			}

			if (letsPlayOutterBgView != null) {
				letsPlayOutterBgView.Dispose ();
				letsPlayOutterBgView = null;
			}

			if (loginIconBgView != null) {
				loginIconBgView.Dispose ();
				loginIconBgView = null;
			}

			if (loginIconImg != null) {
				loginIconImg.Dispose ();
				loginIconImg = null;
			}

			if (loginLbl != null) {
				loginLbl.Dispose ();
				loginLbl = null;
			}

			if (loginLblBgView != null) {
				loginLblBgView.Dispose ();
				loginLblBgView = null;
			}

			if (pwfBtn != null) {
				pwfBtn.Dispose ();
				pwfBtn = null;
			}

			if (pwfOutterBgView != null) {
				pwfOutterBgView.Dispose ();
				pwfOutterBgView = null;
			}
		}
	}
}
