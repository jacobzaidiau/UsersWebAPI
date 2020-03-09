using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;
using UsersWebAPI.IRepository;

namespace UsersWebAPI
{
    public partial class AddUserGroupWebForm : System.Web.UI.Page
    {
        UserGroupRepository userGroupRepository = new UserGroupRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["groupID"] = null;
            }
            ClientScript.GetPostBackEventReference(this, string.Empty);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            List<int> groups = new List<int>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox checkBox = (CheckBox)row.Cells[1].Controls[1];
                if (checkBox.Checked)
                {
                    groups.Add(Convert.ToInt32(row.Cells[0].Text));
                }
            }

            int x = Convert.ToInt32(Session["userID"]);

            List<UserGroup> userGroups = userGroupRepository.AddUserGroups(x, groups);
            if (userGroups.Count == 0)
            {
                Button button = (Button)sender;
                Session["senderID"] = button.ID;
                Response.Redirect(Resources.UserGroupWebForm, false);
            }
            else
            {
                lblMessage.Text = "You have selected groups already assigned to the user.";
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.UserGroupWebForm, false);
        }




    }
}