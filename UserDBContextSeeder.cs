﻿using System;
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
                GroupName = "Receptionist3",
                Description = "Responsible for receiving patients."
            };
            Group group4 = new Group()
            {
                GroupName = "Receptionist4",
                Description = "Responsible for receiving patients."
            };
            Group group5 = new Group()
            {
                GroupName = "Receptionist5",
                Description = "Responsible for receiving patients."
            };
            Group group6 = new Group()
            {
                GroupName = "Receptionist6",
                Description = "Responsible for receiving patients."
            };
            Group group7 = new Group()
            {
                GroupName = "Receptionist7",
                Description = "Responsible for receiving patients."
            };
            Group group8 = new Group()
            {
                GroupName = "Receptionist8",
                Description = "Responsible for receiving patients."
            };
            Group group9 = new Group()
            {
                GroupName = "Receptionist9",
                Description = "Responsible for receiving patients."
            };
            Group group10 = new Group()
            {
                GroupName = "Receptionist10",
                Description = "Responsible for receiving patients."
            };
            Group group11 = new Group()
            {
                GroupName = "Receptionist11",
                Description = "Responsible for receiving patients."
            };
            Group group12 = new Group()
            {
                GroupName = "Receptionist12",
                Description = "Responsible for receiving patients."
            };

            userDBContext.Groups.Add(group1);
            userDBContext.Groups.Add(group2);
            userDBContext.Groups.Add(group3);
            userDBContext.Groups.Add(group4);
            userDBContext.Groups.Add(group5);
            userDBContext.Groups.Add(group6);
            userDBContext.Groups.Add(group7);
            userDBContext.Groups.Add(group8);
            userDBContext.Groups.Add(group9);
            userDBContext.Groups.Add(group10);
            userDBContext.Groups.Add(group11);
            userDBContext.Groups.Add(group12);

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
                Username = "timc3",
                Password = "abc123",
                Firstname = "Tim",
                Lastname = "Charles",
                Email = "tim.charles@corepractice.com.au"
            };

            User user4 = new User()
            {
                Username = "timc4",
                Password = "abc123",
                Firstname = "Tim",
                Lastname = "Charles",
                Email = "tim.charles@corepractice.com.au"
            };

            User user5 = new User()
            {
                Username = "timc5",
                Password = "abc123",
                Firstname = "Tim",
                Lastname = "Charles",
                Email = "tim.charles@corepractice.com.au"
            };

            User user6 = new User()
            {
                Username = "timc6",
                Password = "abc123",
                Firstname = "Tim",
                Lastname = "Charles",
                Email = "tim.charles@corepractice.com.au"
            };

            User user7 = new User()
            {
                Username = "timc7",
                Password = "abc123",
                Firstname = "Tim",
                Lastname = "Charles",
                Email = "tim.charles@corepractice.com.au"
            };

            User user8 = new User()
            {
                Username = "timc8",
                Password = "abc123",
                Firstname = "Tim",
                Lastname = "Charles",
                Email = "tim.charles@corepractice.com.au"
            };

            User user9 = new User()
            {
                Username = "timc9",
                Password = "abc123",
                Firstname = "Tim",
                Lastname = "Charles",
                Email = "tim.charles@corepractice.com.au"
            };

            User user10 = new User()
            {
                Username = "timc10",
                Password = "abc123",
                Firstname = "Tim",
                Lastname = "Charles",
                Email = "tim.charles@corepractice.com.au"
            };

            User user11 = new User()
            {
                Username = "timc11",
                Password = "abc123",
                Firstname = "Tim",
                Lastname = "Charles",
                Email = "tim.charles@corepractice.com.au"
            };

            userDBContext.Users.Add(user1);
            userDBContext.Users.Add(user2);
            userDBContext.Users.Add(user3);
            userDBContext.Users.Add(user4);
            userDBContext.Users.Add(user5);
            userDBContext.Users.Add(user6);
            userDBContext.Users.Add(user7);
            userDBContext.Users.Add(user8);
            userDBContext.Users.Add(user9);
            userDBContext.Users.Add(user10);
            userDBContext.Users.Add(user11);

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