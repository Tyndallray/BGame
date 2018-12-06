using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BGame.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BGame.Controllers
{
    public class GameController : Controller
    {

        IGameItem GameRepository;

        public GameController(IGameItem GameRepository)
        {
            this.GameRepository = GameRepository;

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
        [HttpPost]
        public IActionResult Comment(Comment pCom)
        {
            pCom.date = DateTime.Now;
           // pCom.UserID = User.Identity.AuthenticationType;
            GameRepository.AddComment(pCom);
            GameItem tItem = GameRepository.GameItems.FirstOrDefault(x => x.GameItemId == pCom.GameID);
            return RedirectToAction("GameDetail", new { Id=pCom.GameID});
        }


    }
}