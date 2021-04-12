using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patients : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["PatientsPageCount"] == null)
        {
            Session["PatientsPageCount"] = 0;
        }
        Session["PatientsPageCount"] = (int)Session["PatientsPageCount"] + 1;
    }
}