using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationMonitor.MyClass
{
    class BeaconView : TableLayoutPanel
    {
        private Label macLabel;
        private PictureBox beaconIcon;

        public BeaconView(string mac,Point point) : base()
        {
            this.Size = new Size(45,40);
            this.RowCount = 2;
            this.ColumnCount = 1;
            //this.BackColor = Color.Red;
            this.Location = point;
            macLabel = new Label();
            macLabel.AutoSize = true;
            macLabel.TextAlign = ContentAlignment.MiddleCenter;
            macLabel.Text = mac;
            macLabel.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            beaconIcon = new PictureBox();
            beaconIcon.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom);
            Bitmap source = new Bitmap(Properties.Resources.beacon);
            beaconIcon.ClientSize = new Size(22, 21);
            beaconIcon.Image = source;
            this.Controls.Add(macLabel, 0, 0);
            this.Controls.Add(beaconIcon,0,1);
        }
    }
}
