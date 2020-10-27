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
	[Register ("GameTableView")]
	partial class GameTableView
	{
		[Outlet]
		UIKit.UIButton backBtn { get; set; }

		[Outlet]
		UIKit.UIImageView gameTableImg { get; set; }

		[Outlet]
		UIKit.UIImageView handImg1 { get; set; }

		[Outlet]
		UIKit.UIImageView handImg2 { get; set; }

		[Outlet]
		UIKit.UIImageView handImg3 { get; set; }

		[Outlet]
		UIKit.UIImageView handImg4 { get; set; }

		[Outlet]
		UIKit.UIImageView handImg5 { get; set; }

		[Outlet]
		UIKit.UIView playerScoreView1 { get; set; }

		[Outlet]
		UIKit.UIView playerScoreView2 { get; set; }

		[Outlet]
		UIKit.UIView playerScoreView3 { get; set; }

		[Outlet]
		UIKit.UIView playerScoreView4 { get; set; }

		[Outlet]
		UIKit.UIView playerScoreView5 { get; set; }

		[Outlet]
		UIKit.UIView playerView1 { get; set; }

		[Outlet]
		UIKit.UIView playerView2 { get; set; }

		[Outlet]
		UIKit.UIView playerView3 { get; set; }

		[Outlet]
		UIKit.UIView playerView4 { get; set; }

		[Outlet]
		UIKit.UIView playerView5 { get; set; }

		[Outlet]
		UIKit.UILabel roundNoLbl { get; set; }

		[Action ("onClickBackBtn:")]
		partial void onClickBackBtn (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (backBtn != null) {
				backBtn.Dispose ();
				backBtn = null;
			}

			if (gameTableImg != null) {
				gameTableImg.Dispose ();
				gameTableImg = null;
			}

			if (handImg1 != null) {
				handImg1.Dispose ();
				handImg1 = null;
			}

			if (handImg2 != null) {
				handImg2.Dispose ();
				handImg2 = null;
			}

			if (handImg3 != null) {
				handImg3.Dispose ();
				handImg3 = null;
			}

			if (handImg4 != null) {
				handImg4.Dispose ();
				handImg4 = null;
			}

			if (handImg5 != null) {
				handImg5.Dispose ();
				handImg5 = null;
			}

			if (playerScoreView1 != null) {
				playerScoreView1.Dispose ();
				playerScoreView1 = null;
			}

			if (playerScoreView2 != null) {
				playerScoreView2.Dispose ();
				playerScoreView2 = null;
			}

			if (playerScoreView3 != null) {
				playerScoreView3.Dispose ();
				playerScoreView3 = null;
			}

			if (playerScoreView4 != null) {
				playerScoreView4.Dispose ();
				playerScoreView4 = null;
			}

			if (playerScoreView5 != null) {
				playerScoreView5.Dispose ();
				playerScoreView5 = null;
			}

			if (playerView1 != null) {
				playerView1.Dispose ();
				playerView1 = null;
			}

			if (playerView2 != null) {
				playerView2.Dispose ();
				playerView2 = null;
			}

			if (playerView3 != null) {
				playerView3.Dispose ();
				playerView3 = null;
			}

			if (playerView4 != null) {
				playerView4.Dispose ();
				playerView4 = null;
			}

			if (playerView5 != null) {
				playerView5.Dispose ();
				playerView5 = null;
			}

			if (roundNoLbl != null) {
				roundNoLbl.Dispose ();
				roundNoLbl = null;
			}
		}
	}
}
