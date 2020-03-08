using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UsersWebAPI
{
    public class UserGroup
    {
        public User User { get; set; }
        public Group Group { get; set; }
        
        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        [Key, Column(Order = 2)]
        public int GroupId { get; set; }
    }
}