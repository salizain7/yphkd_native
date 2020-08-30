using Foundation;
using System;
using UIKit;

namespace yphkd.iOS
{
    public partial class SelectFavHandView : UIView
    {
        public SelectFavHandView (IntPtr handle) : base (handle)
        {
        }
        public static SelectFavHandView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("SelectFavHandView", null, null);
            var v = arr.GetItem<SelectFavHandView>(0);
            return v;
        }
    }
}