using Foundation;
using System;
using UIKit;

namespace yphkd.iOS
{
    public partial class SelectHandPopupView : UIView
    {
        public SelectHandPopupView (IntPtr handle) : base (handle)
        {
        }
        public static SelectHandPopupView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("SelectHandPopupView", null, null);
            var v = arr.GetItem<SelectHandPopupView>(0);

            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }
    }
}