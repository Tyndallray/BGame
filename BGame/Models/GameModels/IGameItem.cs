using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGame.Models
{
    public interface IGameItem
    {
        IQueryable<GameItem> GameItems { get; }
        IQueryable<Comment> Comments { get; }
        GameItem DeleteItem(int id) ;
        void SaveGameItem(GameItem item);
        void AddComment(Comment com);
        List<Comment> GetComments(int Id);
        IQueryable<GameItem> GetSellingGame(int pId);
    }
}
