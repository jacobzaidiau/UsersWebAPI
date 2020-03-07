using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;

namespace UsersWebAPI
{
    public partial class UserWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty((string)Session["userID"]))
                {
                    int x = Convert.ToInt32(Session["userID"]);
                    UserDBContext userDBContext = new UserDBContext();
                    User user = (from d in userDBContext.Users
                                 where d.UserId == x
                                 select d).Single();

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        if (GridView1.Rows[i].Cells[0].Text == user.UserId.ToString())
                        {
                            GridView1.SelectedIndex = i;
                            break;
                        }
                    }

                }
                return;
            }
            GridView1.DataSourceID = ObjectDataSource1.ID;
            ClientScript.GetPostBackEventReference(this, string.Empty);
        }

        protected void btnGroups_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)Session["userID"]))
            {
                Button button = (Button)sender;
                Session["senderID"] = button.ID;
                Response.Redirect(Resources.UserGroupWebForm, false);
            }
            else 
            {
                lblMessage.Text = "Please select a row first.";
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.CreateUserWebForm, false);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)Session["userID"]))
            {
                Button button = (Button)sender;
                Session["senderID"] = button.ID;
                Response.Redirect(Resources.CreateUserWebForm, false);
            }
            else 
            {
                lblMessage.Text = "Please select a row first.";
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            UserDBContext userDBContext = new UserDBContext();
            if (!string.IsNullOrEmpty((string)Session["userID"]))
            {
                int x = Convert.ToInt32(Session["userID"]);
                User user = (from d in userDBContext.Users
                             where d.UserId == x
                             select d).Single();
                userDBContext.Users.Remove(user);
                userDBContext.SaveChanges();

                Session["userID"] = null;
                GridView1.SelectedIndex = -1;
            }
            else
            {
                lblMessage.Text = "Please select a row first.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.MainWebForm, false);
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
                    Session["userID"] = row.Cells[0].Text;
                }
            }
        }










    }
}