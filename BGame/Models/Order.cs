using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BGame.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<OrderItem> OrderItemList { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Line1 { get; set; }
        public DateTime date { get; set; }
        public string Line2 { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }
        public bool isCompleted { get; set; }
    }
}
