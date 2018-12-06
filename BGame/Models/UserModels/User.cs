using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace BGame.Models.UserModels
{
    public class User:IdentityUser
    {
     
        public User() : base() { }
        public User(string name) : base(name) { }
        public int UserID { get; set; }
        public string Name { get; set; }
        [UIHint("password")]
        public string Password { set; get; }
        public string ProfileDescription { get; set; }
        public string ProfileLink { set; get; }
        public string ReturnUrl { get; set; }
        //could have many orders
        public ICollection<Order> OrderList { set; get; }
        //for sell
        public ICollection<GameItem> SellingList { set; get; }
    }
   
}
