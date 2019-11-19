using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace saveasze
{
    public partial class poSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["btnSubmit"].ToString().Contains("Update"))
                updStatus.Text = "Updated";
            else
                updStatus.Text = "Created";

        }
    }
}