using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UsersWebAPI
{
    public class UserDBContextSeeder : DropCreateDatabaseIfModelChanges<UserDBContext>
    {
        protected override void Seed(UserDBContext userDBContext) 
        {
            Group group1 = new Group()
            {
                GroupName = "Business owner",
                Description = "Responsible for making business decisions."
            };
            Group group2 = new Group()
            {
                GroupName = "Dentist",
                Description = "Responsible for treating patients."
            };
            Group group3 = new Group()
            {
                GroupName = "Receptionist",
                Description = "Responsible for receiving patients."
            };
            userDBContext.Groups.Add(group1);
            userDBContext.Groups.Add(group2);
            userDBContext.Groups.Add(group3);

            User user1 = new User()
            {
                Username = "johns",
                Password = "abc123",
                Firstname = "John",
                Lastname = "Smith",
                Email = "john.smith@corepractice.com.au"
            };

            User user2 = new User()
            {
                Username = "jamesd",
                Password = "abc123",
                Firstname = "James",
                Lastname = "Daniels",
                Email = "james.daniels@corepractice.com.au"
            };

            User user3 = new User()
            {
                Username = "timc",
                Password = "abc123",
                Firstname = "Tim",
                Lastname = "Charles",
                Email = "tim.charles@corepractice.com.au"
            };

            userDBContext.Users.Add(user1);
            userDBContext.Users.Add(user2);
            userDBContext.Users.Add(user3);

            UserGroup userGroup1 = new UserGroup()
            {
                UserId = 1,
                GroupId = 1
            };

            UserGroup userGroup2 = new UserGroup()
            {
                UserId = 1,
                GroupId = 2
            };

            UserGroup userGroup3 = new UserGroup()
            {
                UserId = 1,
                GroupId = 3
            };

            userDBContext.UserGroups.Add(userGroup1);
            userDBContext.UserGroups.Add(userGroup2);
            userDBContext.UserGroups.Add(userGroup3);

            base.Seed(userDBContext);
        }

    }
}