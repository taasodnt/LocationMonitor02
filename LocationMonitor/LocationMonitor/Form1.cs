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
        public form1()
        {
            InitializeComponent();

            doWork();
            Console.WriteLine("Done");

        }

        private async Task doWork()
        {
            HttpClient client = new HttpClient();
            LoadingForm loading = new LoadingForm();
            loading.Show();
            var task1 = client.GetAsync("http://163.18.53.144/F459/php/c%23_serverbackend/C%23_GetBeaconMac.php");
            var task2 = client.GetAsync("http://163.18.53.144/F459/php/c%23_serverbackend/C%23_GetPhoneMac.php");

               Task.WaitAll(task1, task2);
            
              var data1 = await task1;
              var data2 = await task2;

               var beaconMac = data1.Content.ReadAsStringAsync();
               var phoneMac = data2.Content.ReadAsStringAsync();

               Task.WaitAll(beaconMac, phoneMac);
               string tmp1 = await beaconMac;
               string tmp2 = await phoneMac;

               Console.WriteLine(tmp1.ToString());
               Console.WriteLine(tmp2.ToString());

            Console.WriteLine("do work done");
            loading.Close();
        }
    }
}
