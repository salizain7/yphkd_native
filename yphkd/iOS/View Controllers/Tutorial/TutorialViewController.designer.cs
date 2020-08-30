// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace yphkd.iOS.ViewControllers.Tutorial
{
	[Register ("TutorialViewController")]
	partial class TutorialViewController
	{
		[Outlet]
		UIKit.UIButton continueBtn { get; set; }

		[Outlet]
		UIKit.UIPageControl pageControl { get; set; }

		[Outlet]
		UIKit.UIImageView tutorialBgImgView { get; set; }

		[Outlet]
		UIKit.UICollectionView tutorialCollectionView { get; set; }

		[Action ("onClickContinue:")]
		partial void onClickContinue (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (tutorialCollectionView != null) {
				tutorialCollectionView.Dispose ();
				tutorialCollectionView = null;
			}

			if (pageControl != null) {
				pageControl.Dispose ();
				pageControl = null;
			}

			if (continueBtn != null) {
				continueBtn.Dispose ();
				continueBtn = null;
			}

			if (tutorialBgImgView != null) {
				tutorialBgImgView.Dispose ();
				tutorialBgImgView = null;
			}
		}
	}
}
