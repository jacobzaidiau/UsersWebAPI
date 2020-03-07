using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;

namespace UsersWebAPI.WebForms
{
    public partial class CreateGroupWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            UserDBContext userDBContext = new UserDBContext();

            if (!string.IsNullOrEmpty(txtGroupName.Text))
            {
                Group group = new Group()
                {
                    GroupName = txtGroupName.Text,
                    Description = txtDescription.Text
                };

                userDBContext.Groups.Add(group);
                userDBContext.SaveChanges();
            }
            else 
            {

            }


            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.GroupWebForm, false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.GroupWebForm, false);
        }
    }
}