using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;

namespace UsersWebAPI.WebForms
{
    public partial class GroupWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.CreateGroupWebForm, false);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.CreateGroupWebForm, false);
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            UserDBContext userDBContext = new UserDBContext();
            if (!string.IsNullOrEmpty((string)Session["groupID"]))
            {
                int x = Convert.ToInt32(Session["groupID"]);
                Group group = (from d in userDBContext.Groups
                             where d.GroupId == x
                             select d).Single();
                userDBContext.Groups.Remove(group);
                userDBContext.SaveChanges();
            }
            else
            {

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
                    Session["groupID"] = row.Cells[0].Text;
                }
            }
        }
    }
}