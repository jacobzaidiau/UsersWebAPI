using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;

namespace UsersWebAPI
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                if ((string)Session["senderID"] == "btnBack" && (string)Session["senderURL"] == "UserWebForm") 
                {
                    Session["senderURL"] = null;
                    Session["groupID"] = null;
                }
            }

        }

        protected void btnUsers_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Session["groupID"] = null;
            Response.Redirect(Resources.UserWebForm, false);
        }

        protected void btnGroups_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.GroupWebForm, false);
        }
    }
}