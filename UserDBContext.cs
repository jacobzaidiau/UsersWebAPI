using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UsersWebAPI
{
    public class UserDBContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>()
                .Map(map =>
                {
                    map.Properties(p => new
                    {
                        p.UserId, p.Username, p.Password,
                        p.Firstname, p.Lastname, p.DateOfBirth,
                        p.Email, p.Phone, p.Mobile
                    });
                    map.ToTable("Users");
                })
                .Map(map =>
                {
                    map.Properties(p => new
                    {
                        p.UserId, p.Salt
                    });
                    map.ToTable("UserSalts");
                });
            base.OnModelCreating(modelBuilder);
        }

    }
}