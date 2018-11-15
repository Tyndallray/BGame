using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGame.Models;

namespace BGame.Models.UserModels
{
    public class EFUserRepository : IUserInterface
    {
        private BGameDbContext context;
        public EFUserRepository(BGameDbContext ctx)
        {
            context = ctx;
        }



        public void Add(User obj)
        {
            context.Users.Add(obj);
            context.SaveChanges();
        }

        public IQueryable<User> Users => context.Users;
    }
}
