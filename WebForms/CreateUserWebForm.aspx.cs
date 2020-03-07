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
            if (!Page.IsPostBack) 
            {
                if ((string)Session["senderID"] == "btnUpdate"){
                    int x = Convert.ToInt32(Session["userID"]);
                    UserDBContext userDBContext = new UserDBContext();
                    User user = (from d in userDBContext.Users
                                 where d.UserId == x
                                 select d).Single();


                    txtUsername.Text = user.Username;
                    txtPassword.Text = "";

                    txtFirstname.Text = user.Firstname;
                    txtLastname.Text = user.Lastname;
                    txtDateOfBirth.Text = user.DateOfBirth.ToString();

                    txtEmail.Text = user.Email;
                    txtPhone.Text = user.Phone;
                    txtMobile.Text = user.Mobile;

                }
                return;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if ((string)Session["senderID"] == "btnCreate")
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
            else if ((string)Session["senderID"] == "btnUpdate") 
            {
                UserDBContext userDBContext = new UserDBContext();
                int x = Convert.ToInt32(Session["userID"]);
                User user = (from d in userDBContext.Users
                             where d.UserId == x
                             select d).Single();

                if (!string.IsNullOrEmpty(txtPassword.Text))
                    user.Password = txtPassword.Text;

                user.Firstname = txtFirstname.Text;
                user.Lastname = txtLastname.Text;
                user.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text);

                user.Email = txtEmail.Text;
                user.Phone = txtPhone.Text;
                user.Mobile = txtMobile.Text;

                userDBContext.SaveChanges();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.UserWebForm, false);
        }
    }
}