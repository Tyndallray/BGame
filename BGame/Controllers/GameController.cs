using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BGame.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BGame.Models.UserModels;
namespace BGame.Controllers
{
    public class GameController : Controller
    {

        IGameItem GameRepository;
        IUser UserRepo;

        public GameController(IGameItem GameRepository,IUser userRep)
        {
            this.GameRepository = GameRepository;
            UserRepo = userRep;
        }

        public IActionResult GameDetail(int Id)
        {
            
            GameItem tItem = GameRepository.GameItems.FirstOrDefault(x => x.GameItemId == Id);
            if (tItem.Comments == null)
            {
                tItem.Comments = new List<Comment>(); 

            }
            tItem.Comments.ToList().AddRange(GameRepository.GetComments(Id));
            return View(tItem);
        }

        public ViewResult GameItemList()
        {
            return View(GameRepository.GameItems);
        }

        [Authorize]
        public IActionResult SellingGameList()
        {
            int tID =  UserRepo.curUserID(User.Identity.Name);
            return View( GameRepository.GetSellingGame(tID));
        }

        [Authorize]
        public ViewResult Create() {
                return View("CreateSellingItem", new GameItem());
        }

       public IActionResult CreateSellingItem(GameItem tItem)
        {
            tItem.UserId = UserRepo.curUserID(User.Identity.Name);
            GameRepository.SaveGameItem(tItem);
            return RedirectToAction("SellingGameList");

        }

        [Authorize]
        [HttpPost]
        public IActionResult Comment(Comment pCom)
        {
            pCom.date = DateTime.Now;
            pCom.commenterName = User.Identity.Name; ;
            // pCom.UserID = User.Identity.AuthenticationType;
            GameRepository.AddComment(pCom);
            GameItem tItem = GameRepository.GameItems.FirstOrDefault(x => x.GameItemId == pCom.GameID);
            return RedirectToAction("GameDetail", new { Id=pCom.GameID});
        }


    }
}