using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersWebAPI
{
    public class UserRepository
    {
        public List<Group> GetGroups() 
        {
            UserDBContext userDBContext = new UserDBContext();
            return userDBContext.Groups.ToList();
        }

        public List<User> GetUsers()
        {
            UserDBContext userDBContext = new UserDBContext();
            return userDBContext.Users.ToList();
        }

        public List<User> GetUsersWhere(string firstname, string lastname, string dateOfBirth, string email, string phone, string mobile, int startRowIndex, int maximumRows)
        {
            UserDBContext userDBContext = new UserDBContext();

            DateTime? dateOfBirthAsDate = string.IsNullOrEmpty(dateOfBirth) ? null : (DateTime?)DateTime.Parse(dateOfBirth);


            List<User> users = (from d in userDBContext.Users
                                where d.Firstname.Contains(firstname) && d.Lastname.Contains(lastname) && (dateOfBirthAsDate == null || d.DateOfBirth == dateOfBirthAsDate)
                                && d.Email.Contains(email) && (phone == "" || d.Phone.Contains(phone)) && (mobile == "" || d.Mobile.Contains(mobile))
                                select d).OrderBy(x => x.UserId).Skip(startRowIndex).Take(maximumRows).ToList();
            return users;
        }

        public static int GetTotalCount(string firstname, string lastname, string dateOfBirth, string email, string phone, string mobile, int startRowIndex, int maximumRows)
        {
            UserDBContext userDBContext = new UserDBContext();
            DateTime? dateOfBirthAsDate = string.IsNullOrEmpty(dateOfBirth) ? null : (DateTime?)DateTime.Parse(dateOfBirth);
            return (from d in userDBContext.Users
                    where d.Firstname.Contains(firstname) && d.Lastname.Contains(lastname) && (dateOfBirthAsDate == null || d.DateOfBirth == dateOfBirthAsDate)
                    && d.Email.Contains(email) && (phone == "" || d.Phone.Contains(phone)) && (mobile == "" || d.Mobile.Contains(mobile))
                    select d).Count();
        }

    }
}