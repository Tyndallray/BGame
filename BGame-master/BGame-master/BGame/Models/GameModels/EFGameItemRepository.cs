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
        
    }
}
