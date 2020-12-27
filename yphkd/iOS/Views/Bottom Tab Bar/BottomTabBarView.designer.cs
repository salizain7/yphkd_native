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
	[Register ("BottomTabBarView")]
	partial class BottomTabBarView
	{
		[Outlet]
		UIKit.UIView adView { get; set; }

		[Outlet]
		UIKit.UIButton button1 { get; set; }

		[Outlet]
		UIKit.UIButton button2 { get; set; }

		[Outlet]
		UIKit.UIButton button3 { get; set; }

		[Outlet]
		UIKit.UIButton button4 { get; set; }

		[Outlet]
		UIKit.UIButton button5 { get; set; }

		[Outlet]
		UIKit.UIView safeAreaView { get; set; }

		[Outlet]
		UIKit.UIImageView tab1_icon { get; set; }

		[Outlet]
		UIKit.UIImageView tab2_icon { get; set; }

		[Outlet]
		UIKit.UIImageView tab3_icon { get; set; }

		[Outlet]
		UIKit.UIImageView tab4_icon { get; set; }

		[Outlet]
		UIKit.UIImageView tab5_icon { get; set; }

		[Outlet]
		UIKit.UIView view1 { get; set; }

		[Outlet]
		UIKit.UIView view2 { get; set; }

		[Outlet]
		UIKit.UIView view3 { get; set; }

		[Outlet]
		UIKit.UIView view4 { get; set; }

		[Outlet]
		UIKit.UIView view5 { get; set; }

		[Action ("onClickBtn1:")]
		partial void onClickBtn1 (UIKit.UIButton sender);

		[Action ("onClickBtn2:")]
		partial void onClickBtn2 (UIKit.UIButton sender);

		[Action ("onClickBtn3:")]
		partial void onClickBtn3 (UIKit.UIButton sender);

		[Action ("onClickBtn4:")]
		partial void onClickBtn4 (UIKit.UIButton sender);

		[Action ("onClickBtn5:")]
		partial void onClickBtn5 (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (adView != null) {
				adView.Dispose ();
				adView = null;
			}

			if (button1 != null) {
				button1.Dispose ();
				button1 = null;
			}

			if (button2 != null) {
				button2.Dispose ();
				button2 = null;
			}

			if (button3 != null) {
				button3.Dispose ();
				button3 = null;
			}

			if (button4 != null) {
				button4.Dispose ();
				button4 = null;
			}

			if (button5 != null) {
				button5.Dispose ();
				button5 = null;
			}

			if (safeAreaView != null) {
				safeAreaView.Dispose ();
				safeAreaView = null;
			}

			if (tab1_icon != null) {
				tab1_icon.Dispose ();
				tab1_icon = null;
			}

			if (tab2_icon != null) {
				tab2_icon.Dispose ();
				tab2_icon = null;
			}

			if (tab3_icon != null) {
				tab3_icon.Dispose ();
				tab3_icon = null;
			}

			if (tab4_icon != null) {
				tab4_icon.Dispose ();
				tab4_icon = null;
			}

			if (tab5_icon != null) {
				tab5_icon.Dispose ();
				tab5_icon = null;
			}

			if (view1 != null) {
				view1.Dispose ();
				view1 = null;
			}

			if (view2 != null) {
				view2.Dispose ();
				view2 = null;
			}

			if (view3 != null) {
				view3.Dispose ();
				view3 = null;
			}

			if (view4 != null) {
				view4.Dispose ();
				view4 = null;
			}

			if (view5 != null) {
				view5.Dispose ();
				view5 = null;
			}
		}
	}
}
