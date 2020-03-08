using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersWebAPI.IRepository
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetGroups(int startRowIndex, int maximumRows);
        int GetGroupsTotalCount(int startRowIndex, int maximumRows);
    }
}