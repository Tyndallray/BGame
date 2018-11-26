using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BGame.Models;
using Microsoft.AspNetCore.Authorization;

namespace GamerZone.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        private IGameItem gItemRepository;
        public AdminController(IGameItem repo)
        {
            gItemRepository = repo;
        }
        public ViewResult Index() => View(gItemRepository.GameItems);

        public ViewResult Edit(int pItemID) => View(gItemRepository.GameItems.FirstOrDefault<GameItem>(tItem=>tItem.GameItemId==pItemID));


        public ViewResult Create() {
            return View("Edit",new GameItem());
        }

        
        [HttpPost]
        public IActionResult Edit(GameItem pItem) {
            if (ModelState.IsValid)
            {
                gItemRepository.SaveGameItem(pItem);
                TempData["message"] = $"{pItem.Name} has been saved.";
                return RedirectToAction("Index");
            }
            else {
                return View();
            }
        }
        [HttpPost]
        public IActionResult DeleteItem(int pID) {
            GameItem tItem = gItemRepository.DeleteItem(pID);

            if (tItem != null)
            {
                TempData["message"] = $"{tItem.Name} was deleted.";
            }
            return RedirectToAction("Index");
        }

    }
}