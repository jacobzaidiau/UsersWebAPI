using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsersWebAPI.IRepository;

namespace UsersWebAPI
{
    public class UserGroupRepository : IUserGroupRepository
    {
        UserDBContext userDBContext = new UserDBContext();
        public IEnumerable<Group> GetUserGroups(string userId, int startRowIndex, int maximumRows)
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