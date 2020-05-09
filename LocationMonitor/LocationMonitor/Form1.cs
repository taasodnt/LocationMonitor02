using LocationMonitor.MyClass;
using LocationMonitor.MyForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationMonitor
{
    public partial class form1 : Form
    {
        DataSourceManager dataSourceManager;

        public form1()
        {
            InitializeComponent();
            
            //   doWork();
            dataSourceManager = new DataSourceManager();
            LoadingForm loadingForm = new LoadingForm();
            loadingForm.Show();
            var getBeaconMacTask = dataSourceManager.upDateBeaconQue();
            var getPhoneMacTask = dataSourceManager.upDatePhoneMac();
            Task.WaitAll(getBeaconMacTask, getPhoneMacTask);
            loadingForm.Close();
            Console.WriteLine("Done");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click");
            AddBeaconForm addBeaconForm = new AddBeaconForm(dataSourceManager);
            DialogResult result = addBeaconForm.ShowDialog();
            string returnValue = addBeaconForm.getBeaconMac();
            string[] nickName = returnValue.Split(':');
            //the following "If" is test only
            if (returnValue != "" && returnValue != null && result != DialogResult.Cancel)
            {
                MouseEventArgs mouseEvent = (MouseEventArgs)e;
                Point point = new Point(mouseEvent.X, mouseEvent.Y);
                BeaconView beaconView = new BeaconView(nickName[nickName.Length - 2] + ":" + nickName[nickName.Length - 1], point);
                pictureBox1.Controls.Add(beaconView);
            }
        }

        //nickName[nickName.Length-2]+":"+nickName[nickName.Length-1]


        /* private async Task doWork() //just for test
         {
             HttpClient client = new HttpClient();
             LoadingForm loading = new LoadingForm();
             loading.Show();
             var getBeaconMacTask = client.GetAsync("http://163.18.53.144/F459/php/c%23_serverbackend/C%23_GetBeaconMac.php");
             var getPhoneMacTask = client.GetAsync("http://163.18.53.144/F459/php/c%23_serverbackend/C%23_GetPhoneMac.php");

                Task.WaitAll(getBeaconMacTask, getPhoneMacTask);

               var data1 = await getBeaconMacTask;
               var data2 = await getPhoneMacTask;

                var beaconMac = data1.Content.ReadAsStringAsync();
                var phoneMac = data2.Content.ReadAsStringAsync();

                Task.WaitAll(beaconMac, phoneMac);
                string tmp1 = await beaconMac;
                string tmp2 = await phoneMac;

                Console.WriteLine(tmp1.ToString());
                Console.WriteLine(tmp2.ToString());

             Console.WriteLine("do work done");
             loading.Close();
         }*/

    }
}
