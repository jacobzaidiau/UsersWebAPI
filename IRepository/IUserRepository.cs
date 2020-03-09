using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersWebAPI.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(string firstname, string lastname, string dateOfBirth, string email, string phone, string mobile, int startRowIndex, int maximumRows);
        int GetUsersTotalCount(string firstname, string lastname, string dateOfBirth, string email, string phone, string mobile, int startRowIndex, int maximumRows);

        User SelectUser(int userId);
        bool UsernameExists(string username);
        void AddUser(string username, string password, string firstname, string lastname, DateTime? dateOfBirth, string email, string phone, string mobile);
        void UpdateUser(int userId, string password, string firstname, string lastname, DateTime? dateOfBirth, string email, string phone, string mobile);
        void RemoveUser(int userId);

    }
}