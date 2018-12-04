using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BGame.Models.UserModels
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string ProfileDescription { get; set; }
        public string ReturnUrl { get; set; }
    }
   
}
