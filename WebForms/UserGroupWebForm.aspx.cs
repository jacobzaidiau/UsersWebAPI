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
            UserDBContext userDBContext = new UserDBContext();
            var query = from user in userDBContext.Users
                        from userGroup in user.UserGroups
                        select new
                        {
                            Firstname = user.Firstname,
                            Lastname = user.Lastname,
                            DateOfBirth = user.DateOfBirth,

                            Email = user.Email,
                            Phone = user.Phone,
                            Mobile = user.Mobile,

                            GroupName = userGroup.Group.GroupName,
                            Description = userGroup.Group.Description


                        };
            GridView1.DataSource = query.ToList();
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
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.UserWebForm, false);
        }
    }
}