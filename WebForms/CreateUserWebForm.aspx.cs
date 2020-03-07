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

namespace UsersWebAPI.WebForms
{
    public partial class CreateUserWebForm : System.Web.UI.Page
    {

        public byte[] CreateSalt()  
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
        public byte[] HashPassword(string password, byte[] salt) 
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 1; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 16 * 8; // 1 GB

            return argon2.GetBytes(16);
        }
        private bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

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
            lblMessage.Text = "";
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            UserDBContext userDBContext = new UserDBContext();

            List<User> accountUser = (from d in userDBContext.Users
                                where d.Username == username
                                select d).ToList();

            if (accountUser.Count > 0) 
            {
                lblMessage.Text = "Error: User already exists.";
                return;
            }

            if (password.Length < 8 || !password.Any(c => char.IsUpper(c)))
            {
                lblMessage.Text = "Please enter a valid password.";
                return;
            }

            byte[] salt = CreateSalt();
            byte[] hash = HashPassword(txtPassword.Text, salt);
            bool success = VerifyHash(txtPassword.Text, salt, hash);


            if ((string)Session["senderID"] == "btnCreate")
            {


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
                        Password = Convert.ToBase64String(hash),
                        Salt = Convert.ToBase64String(salt),
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
                    lblMessage.Text = "Please fill in the required text fields.";
                    return;
                }


                Button button = (Button)sender;
                Session["senderID"] = button.ID;
                Response.Redirect(Resources.UserWebForm, false);
            }
            else if ((string)Session["senderID"] == "btnUpdate") 
            {
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


        // TODO use JavaScript for KeyUp/KeyDown handling
        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblPasswordStrength.Text = "";
            string x = txtPassword.Text;
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