using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsersWebAPI.IRepository;

namespace UsersWebAPI
{
    public class UserRepository : IUserRepository
    {
        UserDBContext userDBContext = new UserDBContext();
        public IEnumerable<User> GetUsers(string firstname, string lastname, string dateOfBirth, string email, string phone, string mobile, int startRowIndex, int maximumRows)
        {
            DateTime? dateOfBirthAsDate = string.IsNullOrEmpty(dateOfBirth) ? null : (DateTime?)DateTime.Parse(dateOfBirth);

            List<User> users = (from d in userDBContext.Users
                                where d.Firstname.Contains(firstname) && d.Lastname.Contains(lastname) && (dateOfBirthAsDate == null || d.DateOfBirth == dateOfBirthAsDate)
                                && d.Email.Contains(email) && (phone == "" || d.Phone.Contains(phone)) && (mobile == "" || d.Mobile.Contains(mobile))
                                select d).OrderBy(x => x.UserId).Skip(startRowIndex).Take(maximumRows).ToList();
            return users;
        }
        public int GetUsersTotalCount(string firstname, string lastname, string dateOfBirth, string email, string phone, string mobile, int startRowIndex, int maximumRows)
        {
            DateTime? dateOfBirthAsDate = string.IsNullOrEmpty(dateOfBirth) ? null : (DateTime?)DateTime.Parse(dateOfBirth);

            return (from d in userDBContext.Users
                    where d.Firstname.Contains(firstname) && d.Lastname.Contains(lastname) && (dateOfBirthAsDate == null || d.DateOfBirth == dateOfBirthAsDate)
                    && d.Email.Contains(email) && (phone == "" || d.Phone.Contains(phone)) && (mobile == "" || d.Mobile.Contains(mobile))
                    select d).Count();
        }
    }
}