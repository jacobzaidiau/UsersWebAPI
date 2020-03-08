using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersWebAPI
{
    public class UserRepository
    {
        UserDBContext userDBContext = new UserDBContext();

        public List<Group> GetGroups()
        {
            return userDBContext.Groups.ToList();
        }
        public List<Group> GetGroupsWhere(int startRowIndex, int maximumRows)
        {
            return userDBContext.Groups.OrderBy(x => x.GroupId).Skip(startRowIndex).Take(maximumRows).ToList();
        }
        public int GetGroupsTotalCount(int startRowIndex, int maximumRows)
        {
            return userDBContext.Groups.Count();
        }
        public List<User> GetUsers()
        {
            return userDBContext.Users.ToList();
        }
        public List<User> GetUsersWhere(string firstname, string lastname, string dateOfBirth, string email, string phone, string mobile, int startRowIndex, int maximumRows)
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

        public List<Group> GetUserGroupsWhere(string userId, int startRowIndex, int maximumRows)
        {
            int userIdAsInteger = Convert.ToInt32(userId);

            List<Group> userGroups = (from d in userDBContext.UserGroups
                                      join g in userDBContext.Groups on d.GroupId equals g.GroupId
                                      where d.UserId == userIdAsInteger
                                      select g).OrderBy(x => x.GroupId).Skip(startRowIndex).Take(maximumRows).ToList();
            return userGroups;
        }
        public int GetUserGroupsTotalCount(string userId, int startRowIndex, int maximumRows)
        {
            int userIdAsInteger = Convert.ToInt32(userId);
            int userGroupsCount = (from d in userDBContext.UserGroups
                                   join g in userDBContext.Groups on d.GroupId equals g.GroupId
                                   where d.UserId == userIdAsInteger
                                   select g).Count();
            return userGroupsCount;
        }
    }
}