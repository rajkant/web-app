using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Settings : System.Web.UI.Page
    {
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSleep_Click(object sender, EventArgs e)
        {
            // Hibernate
            //SetSuspendState(true, true, true);
            // Standby
            SetSuspendState(false, true, true);
        }
    }
}