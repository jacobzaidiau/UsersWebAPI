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

        public List<int> groups
        {
            get
            {
                if (ViewState["paramsList"] == null)
                    ViewState["paramsList"] = new List<int>();

                return ViewState["paramsList"] as List<int>;
            }
            set
            {
                ViewState["paramsList"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["groupID"] = null;
            }
            else
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox checkBox = (CheckBox)row.Cells[1].Controls[1];
                if (checkBox.Checked)
                    if (!groups.Any(x => x == Convert.ToInt32(row.Cells[0].Text)))
                        groups.Add(Convert.ToInt32(row.Cells[0].Text));
            }

            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();


            foreach (GridViewRow row in GridView1.Rows)
            {
                if (groups.Contains(Convert.ToInt32(row.Cells[0].Text)))
                {
                    CheckBox checkBox = (CheckBox)row.Cells[1].Controls[1];
                    checkBox.Checked = true;

                }
            }
        }


        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {

        }
    }
}