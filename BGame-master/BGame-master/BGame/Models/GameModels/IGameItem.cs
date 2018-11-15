using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGame.Models
{
    public interface IGameItem
    {
        IQueryable<GameItem> GameItems { get; }
    }
}
