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
        FlowLayoutPanel flowLayoutPanel;
        PictureBox floorPlane;
        TableLayoutPanel floorSketch;
        List<Button> floorButton = new List<Button>();

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
               this.WindowState = FormWindowState.Maximized;
               Console.WriteLine("Done");
               
            //initForm();
        }

        //the function needs dataSourceManager initialize complete totally
        private void initForm()
        {
            flowLayoutPanel = new FlowLayoutPanel();
            floorPlane = new PictureBox();
            Console.WriteLine(this.Size.Height);
            flowLayoutPanel.Size = new Size(this.Size.Width, this.Size.Height);
            flowLayoutPanel.BackColor = Color.Blue;
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
           // flowLayoutPanel.Dock = DockStyle.Fill;

            setFloorSketch();


            floorPlane.BackColor = Color.Green;

            
            

            
            flowLayoutPanel.Controls.Add(floorSketch);
            flowLayoutPanel.Controls.Add(floorPlane);
            this.Controls.Add(flowLayoutPanel);
        }

        private void setFloorSketch()
        {
            floorSketch = new TableLayoutPanel();
            floorSketch.RowCount = dataSourceManager.getFloor();
            floorSketch.ColumnCount = 1;
            floorSketch.BackColor = Color.Red;
            floorSketch.Size = new Size(flowLayoutPanel.Size.Width/7, flowLayoutPanel.Size.Height);
            floorSketch.Margin = new Padding(10, 5, 20, 20);
            //add button into tableLayoutPanel
            for (int i = 0; i < dataSourceManager.getFloor(); i++)
            {
                Button button = new Button();
                button.Text = "floor" + i;
                button.Margin = new Padding(10, 5, 10, 5);
                button.Anchor = (AnchorStyles.Left | AnchorStyles.Right |AnchorStyles.Top | AnchorStyles.Bottom);
                floorButton.Add(button);
                floorSketch.Controls.Add(button, 1, i);
                floorSketch.RowStyles.Add(new RowStyle(SizeType.Percent, floorSketch.Height * (1 / dataSourceManager.getFloor())));
            }

           // SizeType.Percent, floorSketch.Height * (1 / dataSourceManager.getFloor()))

            floorSketch.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            TableLayoutRowStyleCollection styles = floorSketch.RowStyles;
            Console.WriteLine(styles.Count);
           
            foreach (RowStyle style in styles)
            {
                style.SizeType = SizeType.Absolute;
                style.Height = floorSketch.Size.Height / dataSourceManager.getFloor();
                Console.WriteLine(style.Height);
            }
        }


        private void form1_Load(object sender, EventArgs e)
        {
            initForm();
        }

        /*   private void pictureBox1_Click(object sender, EventArgs e)
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
           }*/



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
