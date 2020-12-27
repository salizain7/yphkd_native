using System;

using Foundation;
using UIKit;
using yphkd.iOS.Constants;

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
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            
            this.BackgroundColor = UIColor.FromRGB(0, 63, 177);
            this.Layer.BorderColor = UIColor.White.CGColor;
            this.Layer.BorderWidth = 1;
            this.Layer.CornerRadius = 15;
            tableCoinsLbl.TextColor = UIColor.White;
        }

        public void BindData(string coinsText, string image)
        {
            tableCoinsLbl.Text = coinsText;
            tableCoinsImg.Image = UIImage.FromBundle(image);
        }
        public void setViewTag(int tag)
        {
            this.Tag = tag;
        }
        public int getViewTag()
        {
            return (int)this.Tag;
        }
        public void SetSelected()
        {
            this.BackgroundColor = UIColor.FromRGB(62, 131, 255);
        }
        public void SetUnSelectable()
        {
            this.Alpha = 0.5f;
        }
        
    }
}
