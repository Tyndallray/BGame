using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace BGame.Models
{
    public class EFGameItemRepository : IGameItem
    {
        private BGameDbContext context;
        public IQueryable<GameItem> GameItems => context.GameItems;
        public IQueryable<Comment> Comments => context.Comments;
        public EFGameItemRepository(BGameDbContext context)
        {
            this.context = context;
        }
       

        //currently for delete gameItem in crud (not recommend cause the record) 
        public GameItem DeleteItem(int pID)
        {
            GameItem tItem = context.GameItems.FirstOrDefault(Item => Item.GameItemId == pID);
            if (tItem != null)
            {
                context.GameItems.Remove(tItem);
                context.SaveChanges();
            }
            return tItem;
        }

        // used for edit existing gameItem in crud 
        public void SaveGameItem(GameItem pItem)
        {
            if (pItem.GameItemId == 0)
            {
                context.GameItems.Add(pItem);
            }
            else
            {
                GameItem dbEntry = context.GameItems.FirstOrDefault(tItem => tItem.GameItemId == pItem.GameItemId);
                if (dbEntry != null)
                { 
                    dbEntry.Name = pItem.Name;
                    dbEntry.Description = pItem.Description;
                    dbEntry.Age = pItem.Age;
                    dbEntry.Image = pItem.Image;
                    dbEntry.Players= pItem.Players;
                    dbEntry.Quantity = pItem.Quantity;
                    dbEntry.Price = pItem.Price;
                    dbEntry.UserId = pItem.UserId;
                }
            }
            context.SaveChanges();
        }
        public void AddComment(Comment pCom)
        {
            //if i bought item before then  comment
            GameItem tItem = GameItems.FirstOrDefault(p => p.GameItemId == pCom.GameID);
            if (tItem != null && pCom != null)
            {
                if (tItem.Comments == null)
                {
                    tItem.Comments = new List<Comment>();
                }

                tItem.Comments.Add(pCom);
                context.Comments.Add(pCom);
                context.SaveChanges();
            }
        }

        public List<Comment> GetComments(int pGameID)
        {
            List<Comment> coms = new List<Comment>();
            coms.AddRange(Comments.Where(p => p.GameID == pGameID));
            return coms;
        }

    }
}
