using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

namespace tweetupdater
{
    public partial class dbupdater : ServiceBase
    {
        private Timer timer1 = null;

        public dbupdater()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            this.timer1.Interval = 30000; //Every 30 seconds
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            timer1.Enabled = true;
            Library.WriteErrorLog("DB service started...");
        }

        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            //Write code here to do some job dependes on requirements
            Library.WriteErrorLog("Timer ticked and some job has been done successfully");
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            Library.WriteErrorLog("DB service stopped...");
        }
    }
}
