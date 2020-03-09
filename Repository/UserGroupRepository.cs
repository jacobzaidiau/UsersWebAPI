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
        public IEnumerable<Group> GetUserGroups()
        {
            List<Group> userGroups = (from d in userDBContext.UserGroups
                                      join g in userDBContext.Groups on d.GroupId equals g.GroupId
                                      select g).ToList();
            return userGroups;
        }

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

        public List<UserGroup> AddUserGroups(int userId, List<int> groups) 
        {
            List<UserGroup> userGroups = (from d in userDBContext.UserGroups
                                          where d.UserId == userId && groups.Contains(d.GroupId)
                                          select d).ToList();

            if (userGroups.Count == 0)
            {
                foreach (int group in groups)
                    userDBContext.UserGroups.Add(new UserGroup()
                    {
                        UserId = userId,
                        GroupId = group
                    });
                userDBContext.SaveChanges();
            }
            return userGroups;
        }

        public void RemoveUserGroup(int userId, int groupId) 
        {
            UserGroup userGroup = (from d in userDBContext.UserGroups
                                   where d.UserId == userId && d.GroupId == groupId
                                   select d).Single();
            userDBContext.UserGroups.Remove(userGroup);
            userDBContext.SaveChanges();
        }
        public void ClearUserGroups(int userId) 
        {
            List<UserGroup> userGroups = (from d in userDBContext.UserGroups
                                          where d.UserId == userId
                                          select d).ToList();

            foreach (var userGroup in userGroups)
                userDBContext.UserGroups.Remove(userGroup);
            userDBContext.SaveChanges();
        }
    }
}