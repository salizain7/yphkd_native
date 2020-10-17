using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace yphkd.iOS.ViewControllers.Tutorial.Data
{
    public class TutorialCollectionViewDelegate : UICollectionViewDelegateFlowLayout
    {
        UIViewController rootController;
        public TutorialCollectionViewDelegate(UIViewController parentController)
        {
            
            rootController = parentController;
        }
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(collectionView.Frame.Width, collectionView.Frame.Height);
        }
        
        public override void WillEndDragging(UIScrollView scrollView, CGPoint velocity, ref CGPoint targetContentOffset)
        {
            var x = targetContentOffset.X;
            var y = x / scrollView.Frame.Width;
            if( (System.nint)y == 0)
            {
                var controller = rootController as TutorialViewController;
                if (controller != null )
                {
                    controller.EnableContinueBtn(true);
                }
                
            }
            else
            {
                var controller = rootController as TutorialViewController;
                if (controller != null)
                {
                    if(controller.handleIsSelected == true)
                    {
                        controller.EnableContinueBtn(true);
                    }
                    else
                    {
                        controller.EnableContinueBtn(false);
                    }
                    
                }
            }
            

            //if (CommonMethods.GetUserFromPrefrence().UserLang == "en")
            //{
            //    var x = targetContentOffset.X;
            //    var y = x / scrollView.Frame.Width;
            //    pageControl.CurrentPage = (System.nint)y;
            //}
            //else
            //{
            //    nfloat scrollerWidth = UIScreen.MainScreen.Bounds.Width - 12;
            //    var x = targetContentOffset.X + scrollerWidth;
            //    var y = x / scrollView.Frame.Width;
            //    pageControl.CurrentPage = limitedMatchList.Count - (System.nint)y;
            //}
        }

    }
}
