using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsersWebAPI.Properties;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
using System.Drawing;
using UsersWebAPI.IRepository;

namespace UsersWebAPI.WebForms
{
    public partial class CreateUserWebForm : System.Web.UI.Page
    {
        UserRepository userRepository = new UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ((string)Session["senderID"] == "btnUpdate")
                {
                    int x = Convert.ToInt32(Session["userID"]);

                    User user = userRepository.SelectUser(x);

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
            lblMessage.Text = "";
            string username = txtUsername.Text;
            string password = (string)Session["password"];
            DateTime? dateOfBirth = string.IsNullOrEmpty(txtDateOfBirth.Text) ? null : (DateTime?)DateTime.Parse(txtDateOfBirth.Text);


            if (string.IsNullOrEmpty(password))
                password = "";

            if ((string)Session["senderID"] == "btnCreate")
            {
                if (userRepository.UsernameExists(username) && (string)Session["senderID"] == "btnCreate")
                {
                    lblMessage.Text = "Error: User already exists.";
                    return;
                }
                if (password.Length < 8 || !password.Any(c => char.IsUpper(c)))
                {
                    lblMessage.Text = "Please enter a valid password.";
                    return;
                }
                if (
                    !string.IsNullOrEmpty(username) &&
                    !string.IsNullOrEmpty(password) &&
                    !string.IsNullOrEmpty(txtFirstname.Text) &&
                    !string.IsNullOrEmpty(txtLastname.Text) &&
                    !string.IsNullOrEmpty(txtEmail.Text)
                    )
                {

                    userRepository.AddUser(
                        username,
                        password,
                        txtFirstname.Text,
                        txtLastname.Text,
                        dateOfBirth,
                        txtEmail.Text,
                        txtPhone.Text,
                        txtMobile.Text);

                    Session["password"] = null;
                    Button button = (Button)sender;
                    Session["senderID"] = button.ID;
                    Response.Redirect(Resources.UserWebForm, false);
                }
                else
                {
                    lblMessage.Text = "Please fill in the required text fields.";
                    return;
                }
            }
            else if ((string)Session["senderID"] == "btnUpdate")
            {
                if (!string.IsNullOrEmpty(password) && (password.Length < 8 || !password.Any(c => char.IsUpper(c))))
                {
                    lblMessage.Text = "Please enter a valid password.";
                    return;
                }

                int x = Convert.ToInt32(Session["userID"]);

                userRepository.UpdateUser(x, 
                    txtPassword.Text,
                    txtFirstname.Text,
                    txtLastname.Text,
                    dateOfBirth,
                    txtEmail.Text,
                    txtPhone.Text,
                    txtMobile.Text);

                Session["password"] = null;
                Button button = (Button)sender;
                Session["senderID"] = button.ID;
                Response.Redirect(Resources.UserWebForm, false);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["password"] = null;
            Button button = (Button)sender;
            Session["senderID"] = button.ID;
            Response.Redirect(Resources.UserWebForm, false);
        }


        // TODO use JavaScript for KeyUp/KeyDown handling
        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblPasswordStrength.Text = "";
            string x = txtPassword.Text;
            if (!string.IsNullOrEmpty(x))
            {
                Session["password"] = x;
            }
            if (x.Length < 8 || !x.Any(c => char.IsUpper(c)))
            {
                lblPasswordStrength.Text = "Weak";
                lblPasswordStrength.ForeColor = Color.FromArgb(0x00FF0000);
            }
            else if (!x.Any(c => char.IsLower(c) || !x.Any(d => char.IsLower(d))))
            {
                lblPasswordStrength.Text = "Okay";
                lblPasswordStrength.ForeColor = Color.FromArgb(0x00FFFF00);
            }
            else if (!x.Any(c => !char.IsLetterOrDigit(c)))
            {
                lblPasswordStrength.Text = "Good";
                lblPasswordStrength.ForeColor = Color.FromArgb(0x0000FF00);
            }
            else
            {
                lblPasswordStrength.Text = "Excellent";
                lblPasswordStrength.ForeColor = Color.FromArgb(0x0039D5BA);
            }

        }
    }
}