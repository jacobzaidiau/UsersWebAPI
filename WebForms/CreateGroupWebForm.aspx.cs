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
            if (!Page.IsPostBack)
            {
                if ((string)Session["senderID"] == "btnCreate")
                {

                }
                else if ((string)Session["senderID"] == "btnUpdate")
                {
                    int x = Convert.ToInt32(Session["groupID"]);

                    UserDBContext userDBContext = new UserDBContext();
                    Group group = (from d in userDBContext.Groups
                                   where d.GroupId == x
                                   select d).Single();

                    txtGroupName.Text = group.GroupName;
                    txtDescription.Text = group.Description;
                }
                return;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((string)Session["senderID"] == "btnCreate")
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
            else if ((string)Session["senderID"] == "btnUpdate") 
            {
                int x = Convert.ToInt32(Session["groupID"]);

                UserDBContext userDBContext = new UserDBContext();
                Group group = (from d in userDBContext.Groups
                               where d.GroupId == x
                               select d).Single();

                group.GroupName = txtGroupName.Text;
                group.Description = txtDescription.Text;

                userDBContext.SaveChanges();

                Button button = (Button)sender;
                Session["senderID"] = button.ID;
                Response.Redirect(Resources.GroupWebForm, false);


            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.GroupWebForm, false);
        }
    }
}