using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsersWebAPI
{
    public class Group
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }
        [StringLength(256)]
        public string Description { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }
    }
}