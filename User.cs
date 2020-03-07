using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsersWebAPI
{
    public class User
    {
        // Account Details
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        [StringLength(128)]
        public string Salt { get; set; }

        // Personal Details
        [Required]
        [StringLength(100)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(100)]
        public string Lastname { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // Contact Details
        [Required]
        [StringLength(256)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Mobile { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }
    }
}