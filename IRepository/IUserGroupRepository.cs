using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersWebAPI.IRepository
{
    public interface IUserGroupRepository
    {
        IEnumerable<Group> GetUserGroups();
        IEnumerable<Group> GetUserGroups(string userId, int startRowIndex, int maximumRows);
        int GetUserGroupsTotalCount(string userId, int startRowIndex, int maximumRows);

        List<UserGroup> AddUserGroups(int userId, List<int> groups);


    }
}