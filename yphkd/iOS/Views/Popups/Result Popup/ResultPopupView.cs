using Foundation;
using System;
using UIKit;

namespace yphkd.iOS
{
    public partial class ResultPopupView : UIView
    {
        public ResultPopupView (IntPtr handle) : base (handle)
        {
        }
        public static ResultPopupView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("ResultPopupView", null, null);
            var v = arr.GetItem<ResultPopupView>(0);

            return v;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }
        public void setupForWinner()
        {
            resultTextLbl.Text = "Congratulations ! \n YOU WON";
            coinsLbl.Text = "100 COINS";
        }
        public void setupForLooser()
        {
            resultTextLbl.Text = "YOU LOOSE";
            coinsLbl.Text = "100 COINS";
        }

    }
}