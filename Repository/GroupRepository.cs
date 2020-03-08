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
        
    }
}