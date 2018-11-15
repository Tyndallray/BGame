using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BGame.Models;
namespace BGame.Controllers
{
    public class GameController : Controller
    {
        IGameItem GameRepository;

        public GameController(IGameItem GameRepository)
        {
            this.GameRepository = GameRepository;
        }
        
        public ViewResult GameDetail(int Id)
        {
            return View(GameRepository.GameItems.Where(x => x.GameItemId == Id).FirstOrDefault());
        }
        
        public ViewResult GameItemList()
        {
            return View(GameRepository.GameItems);
        }
    }
}