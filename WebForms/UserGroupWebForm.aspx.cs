using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;

namespace UsersWebAPI
{
    public partial class UserGroupWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.AddUserGroupWebForm, false);
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            UserDBContext userDBContext = new UserDBContext();
            if (!string.IsNullOrEmpty((string)Session["groupID"]))
            {
                int x = Convert.ToInt32(Session["userID"]);
                int y = Convert.ToInt32(Session["groupID"]);
                UserGroup userGroup = (from d in userDBContext.UserGroups
                                       where d.UserId == x && d.GroupId == y
                                       select d).Single();
                userDBContext.UserGroups.Remove(userGroup);
                userDBContext.SaveChanges();

                Session["groupID"] = null;
                GridView1.SelectedIndex = -1;
                Page_Load(null, null);

            }
            else
            {
                lblMessage.Text = "Please select a row first.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            UserDBContext userDBContext = new UserDBContext();
            if (!string.IsNullOrEmpty((string)Session["userID"]))
            {
                int x = Convert.ToInt32(Session["userID"]);
                List<UserGroup> userGroups = (from d in userDBContext.UserGroups
                                        where d.UserId == x
                                        select d).ToList() ;

                foreach (var userGroup in userGroups)
                    userDBContext.UserGroups.Remove(userGroup);
                userDBContext.SaveChanges();

                Session["groupID"] = null;
                GridView1.SelectedIndex = -1;
                Page_Load(null, null);
            }
            else
            {

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.UserWebForm, false);
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