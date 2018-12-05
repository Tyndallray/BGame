using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BGame.Models
{
    public class Comment
    {
        [Key]
        public int commentID { set; get; }
        public int GameID { set; get; }
        public string commenterName { set; get; }
        public string commenterProfile { set; get; }
        public string commentContent { set; get; }
        public DateTime date { set; get; }
        public int UserID { set; get; }
    }
}
