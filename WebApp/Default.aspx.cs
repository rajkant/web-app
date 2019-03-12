using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        { 
            //Response.Write(CelestialCoordinates.CalculateHorizontalCoordinatesPlanets(-85.76,38.32,"Mercury").ToString());
            //Response.Write(CelestialCoordinates.CalculateHorizontalCoordinatesMoon(-85.76, 38.32).ToString());
        }
         
    }
}