using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using yphkd.iOS.Common;

namespace yphkd.iOS.Managers
{
    public class AnimationManager 
    {
        public AnimationManager()
        {
        }
        /// <summary>
        /// Fade the specified view, isIn, duration and onFinished.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="isIn">If set to <c>true</c> is in.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Fade(UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            try
            {
                view.Alpha = isIn ? minAlpha : maxAlpha;
                view.Transform = CGAffineTransform.MakeIdentity();

                //UIView.Animate(duration, () =>
                //{
                //    view.Alpha = isIn ? maxAlpha : minAlpha;

                //}, () => { });

                UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                    () =>
                    {
                        view.Alpha = isIn ? maxAlpha : minAlpha;
                    },
                    onFinished
                );

            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception thrown", ex);
            }

        }

        /// <summary>
        /// Flips the horizontaly.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="isIn">If set to <c>true</c> is in.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void FlipHorizontaly(UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var m34 = (nfloat)(-1 * 0.001);

            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;

            view.Alpha = (nfloat)1.0;

            var minTransform = CATransform3D.Identity;
            minTransform.m34 = m34;
            minTransform = minTransform.Rotate((nfloat)((isIn ? 1 : -1) * Math.PI * 0.5), (nfloat)0.0f, (nfloat)1.0f, (nfloat)0.0f);
            var maxTransform = CATransform3D.Identity;
            maxTransform.m34 = m34;

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Layer.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Layer.AnchorPoint = new CGPoint((nfloat)0.5, (nfloat)0.5f);
                    view.Layer.Transform = isIn ? maxTransform : minTransform;
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                },
                onFinished
            );
        }


        /// <summary>
        /// Flips the verticaly.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="isIn">If set to <c>true</c> is in.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void FlipVerticaly(UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var m34 = (nfloat)(-1 * 0.001);

            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;

            var minTransform = CATransform3D.Identity;
            minTransform.m34 = m34;
            minTransform = minTransform.Rotate((nfloat)((isIn ? 1 : -1) * Math.PI * 0.5), (nfloat)1.0f, (nfloat)0.0f, (nfloat)0.0f);
            var maxTransform = CATransform3D.Identity;
            maxTransform.m34 = m34;

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Layer.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Layer.AnchorPoint = new CGPoint((nfloat)0.5, (nfloat)0.5f);
                    view.Layer.Transform = isIn ? maxTransform : minTransform;
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                },
                onFinished
            );
        }


        /// <summary>
        /// Rotate the specified view, isIn, fromLeft, duration and onFinished.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="isIn">If set to <c>true</c> is in.</param>
        /// <param name="fromLeft">If set to <c>true</c> from left.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Rotate(UIView view, bool isIn, bool fromLeft = true, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeRotation((nfloat)((fromLeft ? -1 : 1) * 720));
            var maxTransform = CGAffineTransform.MakeRotation((nfloat)0.0);

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        /// <summary>
        /// Scale the specified view, isIn, duration and onFinished.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="isIn">If set to <c>true</c> is in.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Scale(UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeScale((nfloat)0.1, (nfloat)0.1);
            var maxTransform = CGAffineTransform.MakeScale((nfloat)1, (nfloat)1);

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        /// <summary>
        /// Slides the horizontaly.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="isIn">If set to <c>true</c> is in.</param>
        /// <param name="fromLeft">If set to <c>true</c> from left.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void SlideHorizontaly(UIView view, bool isIn, bool fromLeft, double duration = 0.2, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeTranslation((fromLeft ? -1 : 1) * view.Bounds.Width, 0);
            var maxTransform = CGAffineTransform.MakeIdentity();

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut, 
                () =>
                {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
            
        }


        /// <summary>
        /// Slides the verticaly.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="isIn">If set to <c>true</c> is in.</param>
        /// <param name="fromTop">If set to <c>true</c> from top.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void SlideVerticaly(UIView view, bool isIn, bool fromTop, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeTranslation(0, (fromTop ? -1 : 1) * view.Bounds.Height);
            var maxTransform = CGAffineTransform.MakeIdentity();

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        /// <summary>
        /// Zoom the specified view, isIn, duration and onFinished.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="isIn">If set to <c>true</c> is in.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Zoom(UIView view, bool isIn, double duration = 0.3, Action onFinished = null, double ScaleFactor = 2.0)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeScale((nfloat)ScaleFactor, (nfloat)ScaleFactor);
            var maxTransform = CGAffineTransform.MakeScale((nfloat)1, (nfloat)1);

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        public static void Bounce(UIView View, Action onFinished = null)
        {
            UIView.Animate(0.15, () =>
            {
                View.Transform = CGAffineTransform.MakeScale(0.9f, 0.9f);
                View.Alpha = 1;
            }, () =>
            {
                UIView.Animate(0.07, () =>
                {
                    View.Transform = CGAffineTransform.MakeScale(1.0f, 1.0f);
                }, onFinished);
            });
        }
        /*
         * func rightInAnimation(withDuration duration: Double = 0.5,withDelay delay : Double = 0.08,forIndex index : Int) {
        self.transform = CGAffineTransform(translationX: self.bounds.width, y: 0)
        UIView.animate(withDuration: duration,delay: delay * Double(index),animations: {
            self.transform = CGAffineTransform(translationX: 0, y: 0)
        })
    }       
        */

        /// <summary>
        /// Rights the in animation for table cell.
        /// </summary>
        /// <param name="View">View.</param>
        /// <param name="Duration">Duration.</param>
        /// <param name="Delay">Delay.</param>
        public static void RightInAnimationForTableCell(UIView View, double Duration, double Delay)
        {
            View.Transform = CGAffineTransform.MakeTranslation(View.Bounds.Width, 0);

            UIView.Animate(Duration, Delay, UIViewAnimationOptions.TransitionFlipFromLeft, () =>
            {
                View.Transform = CGAffineTransform.MakeTranslation(0, 0);
            }, null);
        }

        /// <summary>
        /// Tops the in animation for table cell.
        /// </summary>
        /// <param name="View">View.</param>
        /// <param name="Duration">Duration.</param>
        /// <param name="Delay">Delay.</param>
        public static void TopInAnimationForTableCell(UIView View, double Duration, double Delay, Action OnFinished = null)
        {
            View.Transform = CGAffineTransform.MakeTranslation(0, -View.Bounds.Height);

            UIView.Animate(Duration, Delay, UIViewAnimationOptions.TransitionFlipFromLeft, () =>
            {
                View.Transform = CGAffineTransform.MakeTranslation(0, 0);

            }, () => { OnFinished?.Invoke(); });
        }

        public static void Rotate180(UIView View, double Duration = 0.4)
        {
            View.Transform = CGAffineTransform.MakeIdentity();
            UIView.Animate(Duration, () =>
            {
                View.Transform = CGAffineTransform.MakeRotation((nfloat)(180 * Math.PI) / 180);
            });
        }
        /*
         * //Some examples from below animation gists

 .view = new UIView (new CGRect (50, 50, 70, 100));
 .view.BackgroundColor = UIColor.Red;
 .View.AddSubview ( .view);

 .animations = new Dictionary<string, Action> () {
    { "FadeIn", () => view.Fade (true) },
    { "FadeOut", () => view.Fade (false) },
    { "RotateIn", () => view.Rotate (true) },
    { "RotateOut", () => view.Rotate (false) },
    { "FlipInVerticaly", () => view.FlipVerticaly (true) },
    { "FlipOutVerticaly", () => view.FlipVerticaly (false) },
    { "FlipInHorizontaly", () => view.FlipHorizontaly (true) },
    { "FlipOutHorizontaly", () => view.FlipHorizontaly (false) },
    { "SlideInFromTop", () => view.SlideVerticaly (true, true) },
    { "SlideInFromBottom", () => view.SlideVerticaly (true, false) },
    { "SlideInFromLeft", () => view.SlideHorizontaly (true, true) },
    { "SlideInFromRight", () => view.SlideHorizontaly (true, false) },
    { "SlideOutFromTop", () => view.SlideVerticaly (false, true) },
    { "SlideOutFromBottom", () => view.SlideVerticaly (false, false) },
    { "SlideOutFromLeft", () => view.SlideHorizontaly (false, true) },
    { "SlideOutFromRight", () => view.SlideHorizontaly (false, false) },
    { "ZoomIn", () => view.Zoom (true) },
    { "ZoomOut", () => view.Zoom (false) },
    { "ScaleIn", () => view.Scale (true) },
    { "ScaleOut", () => view.Scale (false) },
};       
        */



        public static void CircleAnimation(CAShapeLayer CirceLayer, double Duration = 1.5, Action OnFinished = null)
        {
            CABasicAnimation Animation = new CABasicAnimation();
            Animation.KeyPath = "strokeEnd";
            Animation.Duration = Duration;
            Animation.AnimationStopped += (sender, e) =>
            {
                OnFinished();
            };
            Animation.From = NSNumber.FromNInt(0);
            Animation.To = NSNumber.FromNInt(1);

            Animation.TimingFunction = CAMediaTimingFunction.FromName(new NSString(CAMediaTimingFunction.Linear));
            CirceLayer.StrokeEnd = 1;

            CirceLayer.AddAnimation(Animation, "animateCircle");

        }



        public static void Fly(UIView SourceView, CGRect TargetFrame, double Duration = 1, double Delay = 3, Action OnFinished = null)
        {
            UIView.Animate(Duration, () =>
            {
                SourceView.Frame = TargetFrame;
            }, () =>
            {
                OnFinished();
            });

        }



        public static void RotateContinous(UIView View, double Duration = 10, Action OnFinished = null)
        {
            
            CABasicAnimation Animation = new CABasicAnimation();
            Animation.KeyPath = "transform.rotation.y";
            Animation.From = NSNumber.FromFloat(0);
            Animation.To = NSNumber.FromFloat((float)(2 * Math.PI));
            Animation.Duration = 3;
            Animation.RepeatCount = 2;
            

            View.Layer.AddAnimation(Animation, "Spin");
            //View.Layer.RemoveAllAnimations();
            
        }

        
    }
}
