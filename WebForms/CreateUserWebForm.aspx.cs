using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;

namespace UsersWebAPI.WebForms
{
    public partial class CreateUserWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            UserDBContext userDBContext = new UserDBContext();

            if (
                !string.IsNullOrEmpty(txtUsername.Text) &&
                !string.IsNullOrEmpty(txtPassword.Text) &&
                !string.IsNullOrEmpty(txtFirstname.Text) &&
                !string.IsNullOrEmpty(txtLastname.Text) &&
                !string.IsNullOrEmpty(txtEmail.Text)
                )
            {
                User user = new User()
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    
                    Firstname = txtFirstname.Text,
                    Lastname = txtLastname.Text,
                    DateOfBirth = string.IsNullOrEmpty(txtDateOfBirth.Text) ? null : (DateTime?)DateTime.Parse(txtDateOfBirth.Text),

                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Mobile = txtMobile.Text
                };

                userDBContext.Users.Add(user);
                userDBContext.SaveChanges();
            }
            else
            {

            }
            

            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.UserWebForm, false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.UserWebForm, false);
        }
    }
}