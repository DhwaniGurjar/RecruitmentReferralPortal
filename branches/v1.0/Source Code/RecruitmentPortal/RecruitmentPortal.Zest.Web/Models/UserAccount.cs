using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruimentPortal.Zest.Web.Models
{
    public class UserAccount
    {
        
        //key
        [Key]
        public int userid { get; set; }
        //username
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        //password
        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public int Role { get; set; }
    }
}
