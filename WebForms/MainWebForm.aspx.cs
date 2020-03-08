using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;
using UsersWebAPI.IRepository;
using Microsoft.Practices.Unity;

namespace UsersWebAPI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        [Dependency]
        public IUserRepository _userRepository { get; set; }
        [Dependency]
        public IGroupRepository _groupRepository { get; set; }
        [Dependency]
        public IUserGroupRepository _userGroupRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
             var users = _userRepository.GetUsers();
             var groups = _groupRepository.GetGroups();
             var userGroups = _userGroupRepository.GetUserGroups();
            if (!Page.IsPostBack) 
            {
                if ((string)Session["senderID"] == "btnBack" && (string)Session["senderURL"] == "UserWebForm") 
                {
                    Session["senderURL"] = null;
                    Session["groupID"] = null;
                }
            }

        }
        protected void btnUsers_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Session["groupID"] = null;
            Response.Redirect(Resources.UserWebForm, false);
        }
        protected void btnGroups_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.GroupWebForm, false);
        }
    }
}