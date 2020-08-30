using Foundation;
using System;
using UIKit;

namespace yphkd.iOS
{
    public partial class WelcomeView : UIView
    {
        public WelcomeView (IntPtr handle) : base (handle)
        {
        }
        public static WelcomeView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("WelcomeView", null, null);
            var v = arr.GetItem<WelcomeView>(0);
            return v;
        }
    }
}