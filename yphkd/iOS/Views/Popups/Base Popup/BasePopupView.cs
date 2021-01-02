using CoreGraphics;
using Foundation;
using System;
using UIKit;
using yphkd.Facade;
using yphkd.iOS.Constants;
using yphkd.iOS.Managers;
using yphkd.Model.GameDefinition;

namespace yphkd.iOS
{
    public partial class BasePopupView : UIView
    {
        SelectTableCollectionView collectionView;
        ResultPopupView resultPopupView;
        SelectHandPopupView selectHandPopupView;
        UIViewController rootController;
        public BasePopupView (IntPtr handle) : base (handle)
        {
        }
        public static BasePopupView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("BasePopupView", null, null);
            var v = arr.GetItem<BasePopupView>(0);

            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            setupView();
            //SetUpBlurBackground();
        }
        private void setupView()
        {
            //mainView.Layer.BorderColor = ColorConstants.BasePopup.bottomView.CGColor;
            //mainView.Layer.BorderWidth = 2;

            mainView.Layer.CornerRadius = 10;
            mainView.Layer.MasksToBounds = true;

            //bottomBtn.SetTitleColor(UIColor.White, UIControlState.Normal);
        }
        partial void onClickBottomBtn(UIButton sender)
        {
            dismissPopup();
        }
        public void showSelectHandPopup(UIViewController controller, string title, string btnTitle = "", bool isBtn = false, int handId = 0)
        {
            rootController = controller;
            selectHandPopupView = SelectHandPopupView.Create();
            
            selectHandPopupView.Frame = new CGRect(0, 0, centerView.Frame.Width, centerView.Frame.Height);
            //selectHandPopupView.setSelected(handId);
            centerView.AddSubview(selectHandPopupView);

            titleLbl.Text = title;

            //bottomBtn.SetTitle("Time: ", UIControlState.Normal);
            bottomBtn.UserInteractionEnabled = isBtn;
        }
        //public void setBtnTitle(string btnTitle)
        //{
        //    bottomBtn.SetTitle(btnTitle, UIControlState.Normal);
        //}
        
        public void showSelectTablePopup(UIViewController controller, string title, string btnTitle, bool isBtn = false)
        {
            rootController = controller;
            collectionView = SelectTableCollectionView.Create();
            
            collectionView.setCollectionView(rootController);
            collectionView.Frame = new CGRect(0, 0, centerView.Frame.Width, centerView.Frame.Height);

            centerView.AddSubview(collectionView);
            titleLbl.TextColor = UIColor.White;
            titleLbl.Text = title;
            //bottomBtn.SetTitle(btnTitle, UIControlState.Normal);
            bottomBtn.UserInteractionEnabled = isBtn;
        }
        public void showWinnerPopup(UIViewController controller, string title, string btnTitle, bool isBtn = false)
        {
            rootController = controller;
            resultPopupView = ResultPopupView.Create();
            resultPopupView.setupForWinner();

            centerView.AddSubview(resultPopupView);

            titleLbl.Text = title;
            //bottomBtn.SetTitle(btnTitle, UIControlState.Normal);
            bottomBtn.UserInteractionEnabled = isBtn;
        }
        public void showLooserPopup(UIViewController controller, string title, string btnTitle, bool isBtn = false)
        {
            rootController = controller;
            resultPopupView = ResultPopupView.Create();
            resultPopupView.setupForLooser();

            centerView.AddSubview(resultPopupView);

            titleLbl.Text = title;
            //bottomBtn.SetTitle(btnTitle, UIControlState.Normal);
            bottomBtn.UserInteractionEnabled = isBtn;
        }

        private void SetUpBlurBackground()
        {
            this.BackgroundColor = UIColor.Clear;


            UIVisualEffect blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);
            UIVisualEffectView visualEffectView = new UIVisualEffectView(blurEffect);
            visualEffectView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            visualEffectView.Alpha = 0.90f;

            this.Layer.MasksToBounds = true;

            this.AddSubview(visualEffectView);
            this.BringSubviewToFront(popupBtn);
            this.BringSubviewToFront(mainView);


        }
        partial void onclickPopupBtn(UIButton sender)
        {
            dismissPopup();
            
        }
        private void dismissPopup() {

           

            //this.RemoveFromSuperview();

            var controller = rootController as HomeViewController;
            if (controller != null)
            {
                AnimationManager.SlideVerticaly(this, false, false, onFinished: () => {
                    AnimationManager.Fade(controller.getPopupView(), false, onFinished: () =>
                    {
                        controller.getPopupView().Hidden = true;

                    });
                });
                
            }
        }

    }
}