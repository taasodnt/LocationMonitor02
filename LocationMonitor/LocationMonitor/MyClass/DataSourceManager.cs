using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LocationMonitor.MyClass
{
    class DataSourceManager
    {
        private Dictionary<string, bool> beaconQue;
        private List<string> phoneMacs;
        private Dictionary<string,Beacon> beacons;
        private int floor = 4;
        private object lockBeaconQueObject = new object();
        private object lockPhoneMacsObject = new object();

        public DataSourceManager()
        {
            beaconQue = new Dictionary<string, bool>();
            phoneMacs = new List<string>();
            beacons = new Dictionary<string, Beacon>();
        }

        //更新可用beacon清單
        public async Task upDateBeaconQue()
        {
            HttpClient client = new HttpClient();
            var getBeaconTask = client.GetAsync("http://163.18.53.144/F459/php/c%23_serverbackend/C%23_GetBeaconMac.php");

            Task.WaitAll(getBeaconTask);

            var returnMessage = await getBeaconTask;
            var convertTask = returnMessage.Content.ReadAsStringAsync();
            Task.WaitAll(convertTask);
            string rawData = await convertTask;
            lock (lockBeaconQueObject)
            {
                foreach (string beaconMac in splitString(rawData, ','))
                {
                    Console.WriteLine(beaconMac);
                    if (!beaconQue.ContainsKey(beaconMac))
                    {
                        beaconQue.Add(beaconMac, true);
                    }
                }
            }
        }

        //更新消防員手機mac
        public async Task upDatePhoneMac()
        {
            HttpClient client = new HttpClient();
            var getPhoneMacTask = client.GetAsync("http://163.18.53.144/F459/php/c%23_serverbackend/C%23_GetPhoneMac.php");

            Task.WaitAll(getPhoneMacTask);

            var returnMessage = await getPhoneMacTask;
            var convertTask = returnMessage.Content.ReadAsStringAsync();
            Task.WaitAll(convertTask);
            string rawData = await convertTask;
            lock (lockPhoneMacsObject)
            {
                foreach (string phoneMac in splitString(rawData, ','))
                {
                    Console.WriteLine(phoneMac);
                    if (!this.phoneMacs.Contains(phoneMac))
                    {
                        this.phoneMacs.Add(phoneMac);
                    }
                }
            }
        }

        public int getFloor()
        {
            return floor;
        }

        public List<string> getBeaconQue()
        {
            return new List<string>(beaconQue.Keys);
        }

        //放置beacon
        public void placeBeacon(string beaconMac, int floor, Point location)
        {
            if (beaconQue.ContainsKey(beaconMac) && beaconQue[beaconMac])
            {
                beacons.Add(beaconMac,new Beacon(beaconMac, floor, location));
                beaconQue[beaconMac] = !beaconQue[beaconMac];
            }

        }

        public void unplaceBeacon(string theBeacon)
        {
            if (beacons.ContainsKey(theBeacon))
            {
                beacons.Remove(theBeacon);
                beaconQue[theBeacon] = !beaconQue[theBeacon];
            }
        }

        private string[] splitString(string origin,char splitChar)
        {
            return origin.Split(splitChar);
        }


    }
}
