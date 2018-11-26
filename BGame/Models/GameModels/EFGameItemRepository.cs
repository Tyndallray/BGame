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
        public EFGameItemRepository(BGameDbContext context)
        {
            this.context = context;
        }

        public IQueryable<GameItem> GameItems => context.GameItems;

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
    }
}
