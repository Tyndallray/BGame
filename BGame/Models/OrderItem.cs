﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BGame.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { set; get; }
        public GameItem GameItem {  set; get; }
        public DateTime date { set; get; }
        public int Quantity {  set; get; }
        public int OrderID { set; get; }
    }
}
