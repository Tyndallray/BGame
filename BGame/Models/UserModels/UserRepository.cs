using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGame.Models.UserModels
{
    public class UserRepository:IUser
    {
        private AppIdentityDbContext context;
        public IQueryable<User> users => context.Users;

        public UserRepository(AppIdentityDbContext con)
        {
            this.context = con;
        }
        public int GetUsers() => users.Count();
        public int curUserID(string name) => users.FirstOrDefault(x => x.UserName == name).UserID;

    }
}
