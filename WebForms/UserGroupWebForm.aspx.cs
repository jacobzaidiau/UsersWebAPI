﻿using System;
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
                            UserId = user.UserId,
                            GroupId = userGroup.Group.GroupId,
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
            UserDBContext userDBContext = new UserDBContext();
            if (!string.IsNullOrEmpty((string)Session["userID"]))
            {
                int x = Convert.ToInt32(Session["userID"]);
                int y = Convert.ToInt32(Session["groupID"]);
                UserGroup userGroup = (from d in userDBContext.UserGroups
                                       where d.UserId == x && d.GroupId == y
                                       select d).Single();
                userDBContext.UserGroups.Remove(userGroup);
                userDBContext.SaveChanges();
            }
            else
            {

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
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
                    Session["userID"] = row.Cells[0].Text;
                    Session["groupID"] = row.Cells[1].Text;
                }
            }
        }
    }
}