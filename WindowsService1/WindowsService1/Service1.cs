using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1
{
    
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer();  

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Service work started" + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval=5000;
            timer.Enabled=true;
        }

        protected override void OnStop()
        {
            WriteToFile("Service Stop" + DateTime.Now);
        }
        private void OnElapsedTime(object sender, ElapsedEventArgs e) 
        {
            WriteToFile("Service continues to work" + DateTime.Now);
        }

        public void WriteToFile (string message)
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory+"/Logs";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string textPath = AppDomain.CurrentDomain.BaseDirectory + "/Logs/myservice.txt";
            if (!File.Exists(textPath))
            {
                using (StreamWriter sw = File.CreateText(textPath))
                {
                    sw.WriteLine(message);
                }
            }
            else 
            {
                using(StreamWriter sw = File.CreateText(textPath))
                {
                    sw.WriteLine(message);
                }
            }
        }
    }
}
