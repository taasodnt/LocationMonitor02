using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationMonitor.MyForm
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            loadingBar.Style = ProgressBarStyle.Marquee;
            loadingBar.MarqueeAnimationSpeed = 10;
            loadingBar.BackColor = Color.Green;
        }
    }
}
