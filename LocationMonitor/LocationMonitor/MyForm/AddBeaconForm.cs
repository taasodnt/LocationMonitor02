using LocationMonitor.MyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationMonitor.MyForm
{
     partial class AddBeaconForm : Form
     {
         public AddBeaconForm(DataSourceManager dataSourceManager)
         {
             InitializeComponent();
             selectCmb.Select();
             foreach(string beacon in dataSourceManager.getBeaconQue())
             {
                selectCmb.Items.Add(beacon);
             }
            selectCmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            selectCmb.AutoCompleteSource = AutoCompleteSource.ListItems;
         }

         private void AddBeaconForm_Load(object sender, EventArgs e)
         {
            this.TopMost = true;
         }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            // send data back to form1
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        public string getBeaconMac()
        {
            return selectCmb.Text;
        }
    }
}
