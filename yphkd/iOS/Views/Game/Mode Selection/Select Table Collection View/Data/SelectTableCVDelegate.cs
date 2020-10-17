using System;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using UIKit;
using yphkd.Facade;
using yphkd.iOS.Common;
using yphkd.iOS.Managers;
using yphkd.iOS.Views.Game.ModeSelection.SelectTableCollectionView.Cell;

namespace yphkd.iOS.Views.Game.ModeSelection.SelectTableCollectionView.Data
{
    public class SelectTableCVDelegate: UICollectionViewDelegateFlowLayout
    {
        GameTableView gameTableView;
        UIViewController controller;
        

        public SelectTableCVDelegate(UIViewController rootController)
        {
            controller = rootController;
        }
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(collectionView.Frame.Width/2 - 40, collectionView.Frame.Height/2 - 40);
        }
        //public override nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        //{
        //    return 20;
        //}

        public override UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        {

            var flowLayout = layout as UICollectionViewFlowLayout;

            var numberOfItems = collectionView.NumberOfItemsInSection(section: section);
            var combinedItemWidth = (numberOfItems * flowLayout.ItemSize.Width) + ((numberOfItems - 1) * flowLayout.MinimumInteritemSpacing);
            var padding = (collectionView.Frame.Width - combinedItemWidth) / 2;
            var topPadding = (collectionView.Frame.Height - ((2 * flowLayout.ItemSize.Height) + ((2 - 1) * flowLayout.MinimumInteritemSpacing)) ) / 2;
            return new UIEdgeInsets(top: topPadding, left: padding, bottom: 0, right: padding);
            
        }
        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.CellForItem(indexPath) as SelectTableCollectionViewCell;
            if (cell != null)
            {
                AnimationManager.Bounce(cell.ContentView, onFinished: async ()=> {

                    GameManager gameManager = new GameManager();
                    await gameManager.UserPlayRequest(5);
                    var homeViewcontroller = controller as HomeViewController;
                    if(homeViewcontroller != null)
                    {
                        AnimationManager.Fade(homeViewcontroller.getPopupView(), false,duration: 0.8, onFinished: ()=> {
                            //homeViewcontroller.View.SendSubviewToBack(homeViewcontroller.getPopupView());
                            homeViewcontroller.getPopupView().Hidden = true;
                            
                            gameTableView = GameTableView.Create();
                            gameTableView.Frame = new CGRect(0, 0, homeViewcontroller.getMainView().Frame.Size.Width, homeViewcontroller.getMainView().Frame.Size.Height);
                            gameTableView.setRootController(homeViewcontroller);
                            
                            gameTableView.setupPlayerView(cell.getViewTag());
                            gameTableView.setupPlayerScoreView(cell.getViewTag()) ;
                            
                            CommonMethods.clearView(homeViewcontroller.getMainView());
                            homeViewcontroller.getBottomView().showAdView(true);

                            homeViewcontroller.getMainView().AddSubview(gameTableView);
                            AnimationManager.Fade(gameTableView, true);
                            gameTableView.showWaitingPopup();

                        });
                        
                        
                    }
                    
                });
               
            }
            
        }
    }
}
