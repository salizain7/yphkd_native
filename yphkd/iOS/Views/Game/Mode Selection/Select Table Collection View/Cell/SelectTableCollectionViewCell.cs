using System;

using Foundation;
using UIKit;

namespace yphkd.iOS.Views.Game.ModeSelection.SelectTableCollectionView.Cell
{
    public partial class SelectTableCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("SelectTableCollectionViewCell");
        public static readonly UINib Nib;

        static SelectTableCollectionViewCell()
        {
            Nib = UINib.FromName("SelectTableCollectionViewCell", NSBundle.MainBundle);
        }

        protected SelectTableCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void BindData(string coinsText)
        {
            tableCoinsLbl.Text = coinsText;
        }
        public void setViewTag(int tag)
        {
            this.Tag = tag;
        }
        public int getViewTag()
        {
            return (int)this.Tag;
        }
        
    }
}
