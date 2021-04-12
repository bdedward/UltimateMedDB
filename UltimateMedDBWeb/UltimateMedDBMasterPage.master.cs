using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UltimateMedDBMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Application["TotalPageCount"] == null)
        {
            Application["TotalPageCount"] = 0;
        }
        Application["TotalPageCount"] = (int)Application["TotalPageCount"] + 1;
    }
}
