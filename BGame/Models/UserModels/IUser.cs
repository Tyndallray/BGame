using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGame.Models.UserModels
{
   public interface IUser
    {
        IQueryable<User> users {  get; }
        int GetUsers();
        int curUserID(string name);
    }
}
