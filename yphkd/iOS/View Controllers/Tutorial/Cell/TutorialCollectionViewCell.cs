using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace yphkd.iOS.ViewControllers.Tutorial.Cell
{
    public partial class TutorialCollectionViewCell : UICollectionViewCell
    {
        public WelcomeView welcomeView;
        public SelectFavHandView selectFavHandView;

        public static readonly NSString Key = new NSString("TutorialCollectionViewCell");
        public static readonly UINib Nib;

        static TutorialCollectionViewCell()
        {
            Nib = UINib.FromName("TutorialCollectionViewCell", NSBundle.MainBundle);
        }

        protected TutorialCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public void setupTutorial(int cellNo, UIViewController parentController)
        {
            if(cellNo == 0)
            {
                welcomeView = WelcomeView.Create();
                welcomeView.Frame = new CGRect(0, 0, this.Frame.Size.Width, this.Frame.Size.Height);
                this.AddSubview(welcomeView);
            }
            else
            {
                selectFavHandView = SelectFavHandView.Create();
                selectFavHandView.setRootController(parentController);
                selectFavHandView.Frame = new CGRect(0, 0, this.Frame.Size.Width, this.Frame.Size.Height);
                this.AddSubview(selectFavHandView);
            }
        }
        
    }
}
