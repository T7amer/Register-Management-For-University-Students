using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
public partial class MasterPage : System.Web.UI.MasterPage
{
    DataAccess DA = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void lblLogout_Click(object sender, EventArgs e)
    {

    }
}
