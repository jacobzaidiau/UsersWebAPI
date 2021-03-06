﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersWebAPI.IRepository
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetGroups();
        IEnumerable<Group> GetGroups(int startRowIndex, int maximumRows);
        int GetGroupsTotalCount(int startRowIndex, int maximumRows);

        Group SelectGroup(int groupId);
        void AddGroup(string groupName, string description);
        void UpdateGroup(int groupId, string groupName, string description);
        void RemoveGroup(int groupId);
    }
}