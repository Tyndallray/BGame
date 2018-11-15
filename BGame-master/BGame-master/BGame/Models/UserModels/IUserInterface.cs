using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGame.Models.UserModels
{
    public interface IUserInterface
    {
        IQueryable<User> Users { get; }
        void Add(User obj);

    }
}
