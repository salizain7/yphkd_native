// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
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
        }
    }
}