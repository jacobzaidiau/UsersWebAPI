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
        GroupRepository groupRepository = new GroupRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty((string)Session["groupID"]))
                {
                    int x = Convert.ToInt32(Session["groupID"]);
                    Group group = groupRepository.SelectGroup(x);

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        if (GridView1.Rows[i].Cells[0].Text == group.GroupId.ToString())
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

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.CreateGroupWebForm, false);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)Session["groupID"]))
            {
                Button button = (Button)sender;
                Session["senderID"] = button.ID;
                Response.Redirect(Resources.CreateGroupWebForm, false);
            }
            else 
            {
                lblMessage.Text = "Please select a group first.";
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!string.IsNullOrEmpty((string)Session["groupID"]))
            {
                int x = Convert.ToInt32(Session["groupID"]);
                groupRepository.RemoveGroup(x);

                Session["groupID"] = null;
                GridView1.SelectedIndex = -1;
                GridView1.PageIndex = 0;

            }
            else
            {
                lblMessage.Text = "Please select a group first.";
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
                e.Row.ToolTip = "Click to select this group.";
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