using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BGame.Models.UserModels
{
    //public class User:IdentityUser
    //{
    public class User {
        //public async Task<ClaimsIdentity>
        //GenerateUserIdentityAsync(UserManager<User> manager)
        //{
        //    var userIdentity = await manager
        //        .(this);
        //    return userIdentity;
        //}
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfileDescription { get; set; }
        public string ReturnUrl { get; set; }
        //could have many orders
        public ICollection<Order> OrderList { set; get; }
        //for sell
        public ICollection<GameItem> SellingList { set; get; }
    }
   
}
