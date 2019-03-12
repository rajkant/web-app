using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FluentScheduler;

namespace WebApp
{
    public partial class Scheduler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListSchedule_Click(object sender, EventArgs e)
        {

        }

        protected void btnScheduleTask_Click(object sender, EventArgs e)
        {
            JobManager.AddJob(() => Response.Write("hi"), (s) => s.ToRunEvery(500).Seconds());

            //var registry = new Registry();
            //registry.Schedule<MyJob>().ToRunNow().AndEvery(2).Seconds();
            //registry.Schedule<MyJob>().ToRunOnceIn(5).Seconds();
            //registry.Schedule(() => Console.WriteLine("It's 9:15 PM now.")).ToRunEvery(1).Days().At(21, 15);
            //registry.Schedule<MyComplexJob>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Monday).At(3, 0);
            //registry.Schedule<MyJob>().AndThen<MyOtherJob>().ToRunNow().AndEvery(5).Minutes();
            //Schedule<MyJob>().ToRunEvery(0).Weeks().On(DayOfWeek.Monday).At(14, 0);
            //Schedule<MyJob>().ToRunEvery(1).Weeks().On(DayOfWeek.Monday).At(14, 0);
        }

        protected void btnStopScheduler_Click(object sender, EventArgs e)
        {
            //JobManager.Stop();
            JobManager.StopAndBlock();
        }
    }
}