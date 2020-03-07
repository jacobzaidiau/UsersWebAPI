using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;

namespace UsersWebAPI
{
    public partial class AddUserGroupWebForm : System.Web.UI.Page
    {
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
            if (!string.IsNullOrEmpty((string)Session["groupID"]))
            {

                int x = Convert.ToInt32(Session["userID"]);
                int y = Convert.ToInt32(Session["groupID"]);

                UserDBContext userDBContext = new UserDBContext();

                List<UserGroup> userGroups = (from d in userDBContext.UserGroups
                                       where d.UserId == x && d.GroupId == y
                                       select d).ToList();

                if (userGroups.Count == 0)
                {
                    UserGroup userGroup = new UserGroup()
                    {
                        UserId = Convert.ToInt32(Session["userID"]),
                        GroupId = Convert.ToInt32(Session["groupID"])
                    };
                    userDBContext.UserGroups.Add(userGroup);
                    userDBContext.SaveChanges();

                    Button button = (Button)sender;
                    Session["senderID"] = button.ID;
                    Response.Redirect(Resources.UserGroupWebForm, false);
                }
                else 
                {
                    lblMessage.Text = "This group is already assigned to the user.";
                }
            }
            else 
            {
                lblMessage.Text = "Please select a group before submitting or click the Back button.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.UserGroupWebForm, false);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    Session["groupID"] = row.Cells[0].Text;
                }
            }
        }


    }
}