using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart_DAL
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }

        [Required, StringLength(25)]
        public string UserName { get; set; }

        [Required, StringLength(30)]
        public string Password { get; set; }
    }
}
