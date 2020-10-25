using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using yphkd.iOS.Constants;
using yphkd.iOS.ViewControllers.Tutorial;

namespace yphkd.iOS.Common
{
    public class CommonMethods
    {
        public CommonMethods()
        {
        }
        public static AppDelegate GetAppDelegate()
        {
            return UIApplication.SharedApplication.Delegate as AppDelegate;
        }
        public static void SetupInitialScreen(UIWindow Window)
        {
            var appDelegate = GetAppDelegate();
            
            appDelegate.Window = new UIWindow(UIScreen.MainScreen.Bounds);

            appDelegate.Window.RootViewController = new SplashViewController();
            appDelegate.Window.MakeKeyAndVisible();


        }
        public static void SetupHomeScreen()
        {
            
            var appDelegate = GetAppDelegate();
            if (appDelegate.Window == null)
                appDelegate.Window = new UIWindow(UIScreen.MainScreen.Bounds);
            //appDelegate.Window.WindowLevel = nfloat.MaxValue;
            appDelegate.Window.RootViewController = new UINavigationController(new HomeViewController());
            appDelegate.Window.MakeKeyAndVisible();
            
        }
        public static void SetupTutorialScreen()
        {

            var appDelegate = GetAppDelegate();
            if (appDelegate.Window == null)
                appDelegate.Window = new UIWindow(UIScreen.MainScreen.Bounds);
            //appDelegate.Window.WindowLevel = nfloat.MaxValue;
            appDelegate.Window.RootViewController = new UINavigationController(new TutorialViewController());
            appDelegate.Window.MakeKeyAndVisible();

        }
        public static CAGradientLayer addGradient(UIView view, CGColor startColor, CGColor endColor, bool isHorizontal = true)
        {
            var startPoint = new CGPoint(0, 0.5);
            var endPoint = new CGPoint(1, 0.5);

            if (!isHorizontal)
            {
                startPoint = new CGPoint(1, 0);
                endPoint = new CGPoint(1, 1);
            }
            var gradientLayer = new CAGradientLayer()
            {
                StartPoint = startPoint,
                EndPoint = endPoint
            };
            gradientLayer.Colors = new CGColor[] { startColor, endColor };
            gradientLayer.Frame = view.Bounds;

            
            
            view.Layer.InsertSublayer(gradientLayer, 0);
            //view.Layer.MasksToBounds = true;

            return gradientLayer;

        }
        
        public static void clearView(UIView view)
        {
            var subviews = view.Subviews; 
            foreach (var sbview in subviews){
                sbview.RemoveFromSuperview();
            }
        }
        public static void makeRoundCircle(UIView view)
        {
            //view.Layer.CornerRadius = (nfloat)Math.Min(view.Frame.Size.Width / 2, view.Frame.Size.Height / 2);
            view.Layer.CornerRadius = view.Frame.Size.Width / 2.0f;
            //view.Layer.MasksToBounds = true;
            view.ClipsToBounds = true;
        }
        public static void RoundCorners(UIView view, float radius)
        {
            view.Layer.CornerRadius = radius;
            view.Layer.MasksToBounds = true;
        }
        public static void AddShadow(UIView view, UIColor color, float shadowOpacity = 0.41f, float x = 0, float y = 1, float shadowRadius = 1)
        {
            view.Layer.MasksToBounds = false;
            view.Layer.ShadowColor = color.CGColor;
            //letsPlayInnerBgView.Layer.ShadowPath = UIBezierPath.FromRoundedRect(letsPlayInnerBgView.Bounds, UIRectCorner.BottomLeft | UIRectCorner.BottomRight,new CGSize(0,(letsPlayInnerBgView.Frame.Width / 8))).CGPath;

            view.Layer.ShadowRadius = shadowRadius;
            view.Layer.ShadowOffset = new CGSize(x, y);
            view.Layer.ShadowOpacity = shadowOpacity;

        }
        public static void SetUpBlurBackground(UIView view)
        {
            view.BackgroundColor = UIColor.Clear;


            UIVisualEffect blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);
            UIVisualEffectView visualEffectView = new UIVisualEffectView(blurEffect);
            visualEffectView.Frame = new CGRect(0, 0, view.Frame.Width, view.Frame.Height);
            visualEffectView.Alpha = 0.90f;

            view.Layer.MasksToBounds = true;

            view.AddSubview(visualEffectView);

        }
        
        public static string GetHandImage(int id)
        {
            switch (id)
            {
                case 1:
                    return ImageConstants.Hands.hand_1;

                case 2:
                    return ImageConstants.Hands.hand_2;
                case 3:
                    return ImageConstants.Hands.hand_3;
                case 4:
                    return ImageConstants.Hands.hand_4;
                case 5:
                    return ImageConstants.Hands.hand_5;
                default:
                    return ImageConstants.Hands.hand_5;
            }
        }
    }
}
