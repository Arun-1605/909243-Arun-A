using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Models
{
    public class ApplicationUser
    {
        [Key]
        public int UserId { get; set; }
        [Required,StringLength(30)]
        public string UserName { get; set; }
        [Required, StringLength(10)]
        public string Password { get; set; }
    }
}