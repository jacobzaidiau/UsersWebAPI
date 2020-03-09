using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsersWebAPI.IRepository;

namespace UsersWebAPI
{
    public class GroupRepository : IGroupRepository
    {
        UserDBContext userDBContext = new UserDBContext();
        public IEnumerable<Group> GetGroups()
        {
            return userDBContext.Groups.ToList();
        }

        public IEnumerable<Group> GetGroups(int startRowIndex, int maximumRows)
        {
            return userDBContext.Groups.OrderBy(x => x.GroupId).Skip(startRowIndex).Take(maximumRows).ToList();
        }
        public int GetGroupsTotalCount(int startRowIndex, int maximumRows)
        {
            return userDBContext.Groups.Count();
        }

        public Group SelectGroup(int groupId) 
        {
            Group group = (from d in userDBContext.Groups
                           where d.GroupId == groupId
                           select d).Single();
            return group;
        }

        public void AddGroup(string groupName, string description) 
        {
            Group group = new Group()
            {
                GroupName = groupName,
                Description = description
            };

            userDBContext.Groups.Add(group);
            userDBContext.SaveChanges();
        }

        public void UpdateGroup(int groupId, string groupName, string description) 
        {
            Group group = (from d in userDBContext.Groups
                           where d.GroupId == groupId
                           select d).Single();

            group.GroupName = groupName;
            group.Description = description;

            userDBContext.SaveChanges();
        }

        public void RemoveGroup(int groupId) 
        {
            Group group = (from d in userDBContext.Groups
                           where d.GroupId == groupId
                           select d).Single();
            userDBContext.Groups.Remove(group);
            userDBContext.SaveChanges();
        }
        
    }
}