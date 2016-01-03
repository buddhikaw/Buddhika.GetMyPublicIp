using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Buddhika.GetMyPublicIp.Workflow;
using System.Activities;
using System.Activities.Statements;

namespace Buddhika.GetMyPublicIp.HostService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
                      
        }

        protected override void OnStart(string[] args)
        {
            Activity workflow1 = new Workflow1();
            //WorkflowInvoker.Invoke(workflow1);
            WorkflowApplication wfApp = new WorkflowApplication(workflow1);
            wfApp.Run();
        }

        protected override void OnStop()
        {
        }
    }
}
