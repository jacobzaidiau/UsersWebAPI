using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsersWebAPI.IRepository;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;
using System.Text;

namespace UsersWebAPI
{
    public class UserRepository : IUserRepository
    {
        UserDBContext userDBContext = new UserDBContext();
        public IEnumerable<User> GetUsers()
        {
            List<User> users = (from d in userDBContext.Users
                                select d).ToList();
            return users;
        }

        public IEnumerable<User> GetUsers(string firstname, string lastname, string dateOfBirth, string email, string phone, string mobile, int startRowIndex, int maximumRows)
        {
            DateTime? dateOfBirthAsDate = null;
            DateTime parseDateOfBirth;

            if (!string.IsNullOrEmpty(dateOfBirth))
            {
                bool valid = DateTime.TryParse(dateOfBirth, out parseDateOfBirth);
                if (!valid)
                {
                    return new List<User>();
                }
                else
                {
                    dateOfBirthAsDate = parseDateOfBirth;
                }
            }

            List<User> users = (from d in userDBContext.Users
                                where d.Firstname.Contains(firstname) && d.Lastname.Contains(lastname) && (dateOfBirthAsDate == null || d.DateOfBirth == dateOfBirthAsDate)
                                && d.Email.Contains(email) && (phone == "" || d.Phone.Contains(phone)) && (mobile == "" || d.Mobile.Contains(mobile))
                                select d).OrderBy(x => x.UserId).Skip(startRowIndex).Take(maximumRows).ToList();
            return users;
        }
        public int GetUsersTotalCount(string firstname, string lastname, string dateOfBirth, string email, string phone, string mobile, int startRowIndex, int maximumRows)
        {
            DateTime? dateOfBirthAsDate = null;
            DateTime parseDateOfBirth;

            if (!string.IsNullOrEmpty(dateOfBirth))
            {
                bool valid = DateTime.TryParse(dateOfBirth, out parseDateOfBirth);
                if (!valid)
                {
                    return 0;
                }
                else
                {
                    dateOfBirthAsDate = parseDateOfBirth;
                }
            }
            return (from d in userDBContext.Users
                    where d.Firstname.Contains(firstname) && d.Lastname.Contains(lastname) && (dateOfBirthAsDate == null || d.DateOfBirth == dateOfBirthAsDate)
                    && d.Email.Contains(email) && (phone == "" || d.Phone.Contains(phone)) && (mobile == "" || d.Mobile.Contains(mobile))
                    select d).Count();
        }

        public User SelectUser(int userId) 
        {
            User user = (from d in userDBContext.Users
                         where d.UserId == userId
                         select d).Single();
            return user;
        }

        public bool UsernameExists(string username) 
        {
            List<User> user = (from d in userDBContext.Users
                                      where d.Username == username
                                      select d).ToList();
            return user.Count > 0;
        }

        public void AddUser(string username, string password, string firstname, string lastname, DateTime? dateOfBirth, string email, string phone, string mobile) 
        {

            byte[] salt = CreateSalt();
            byte[] hash = HashPassword(password, salt);
            bool success = VerifyHash(password, salt, hash);

            User user = new User()
            {
                Username = username,
                Password = Convert.ToBase64String(hash),
                Salt = Convert.ToBase64String(salt),

                Firstname = firstname,
                Lastname = lastname,
                DateOfBirth = dateOfBirth,

                Email = email,
                Phone = phone,
                Mobile = mobile
            };

            userDBContext.Users.Add(user);
            userDBContext.SaveChanges();
        }

        public void UpdateUser (int userId, string password, string firstname, string lastname, DateTime? dateOfBirth, string email, string phone, string mobile)
        {
            User user = (from d in userDBContext.Users
                         where d.UserId == userId
                         select d).Single();

            if (!string.IsNullOrEmpty(password))
            {
                byte[] salt = CreateSalt();
                byte[] hash = HashPassword(password, salt);
                bool success = VerifyHash(password, salt, hash);

                user.Password = Convert.ToBase64String(hash);
                user.Salt = Convert.ToBase64String(salt);
            }

            user.Firstname = firstname;
            user.Lastname = lastname;
            user.DateOfBirth = dateOfBirth;

            user.Email = email;
            user.Phone = phone;
            user.Mobile = mobile;

            userDBContext.SaveChanges();
        }

        public void RemoveUser(int userId) 
        {
            User user = (from d in userDBContext.Users
                         where d.UserId == userId
                         select d).Single();
            userDBContext.Users.Remove(user);
            userDBContext.SaveChanges();
        }

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
    }
}