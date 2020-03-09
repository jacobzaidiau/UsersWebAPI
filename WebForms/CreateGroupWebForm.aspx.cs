using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;
using UsersWebAPI.IRepository;

namespace UsersWebAPI.WebForms
{
    public partial class CreateGroupWebForm : System.Web.UI.Page
    {
        GroupRepository groupRepository = new GroupRepository();
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
                    Group group = groupRepository.SelectGroup(x);

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
                if (!string.IsNullOrEmpty(txtGroupName.Text))
                {
                    groupRepository.AddGroup(txtGroupName.Text, txtDescription.Text);

                    Button button = (Button)sender;
                    Session["senderID"] = button.ID;
                    Response.Redirect(Resources.GroupWebForm, false);
                }
                else
                {
                    lblMessage.Text = "Please enter a name for your group before proceeding.";
                }
            }
            else if ((string)Session["senderID"] == "btnUpdate") 
            {
                int x = Convert.ToInt32(Session["groupID"]);

                if (!string.IsNullOrEmpty(txtGroupName.Text))
                {
                    groupRepository.UpdateGroup(x, txtGroupName.Text, txtDescription.Text);
                    Button button = (Button)sender;
                    Session["senderID"] = button.ID;
                    Response.Redirect(Resources.GroupWebForm, false);
                }
                else 
                {
                    lblMessage.Text = "Please enter a name for your group before proceeding."; 
                }
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