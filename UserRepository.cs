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
    }
}