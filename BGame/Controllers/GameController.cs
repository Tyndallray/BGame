using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BGame.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace BGame.Controllers
{
    public class GameController : Controller
    {
        private readonly BGameDbContext _context;
        IGameItem GameRepository;

        public GameController(IGameItem GameRepository, BGameDbContext context)
        {
            this.GameRepository = GameRepository;
            _context = context;
        }
        
        public ViewResult GameDetail(int Id)
        {
            return View(GameRepository.GameItems.Where(x => x.GameItemId == Id).FirstOrDefault());
        }
        
        public ViewResult GameItemList()
        {
            return View(GameRepository.GameItems);
        }

        // TEST START HERE

       

        //public GameController(BGameDbContext context)
        //{
        //    _context = context;
        //}

        // GET: GameItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameItems.ToListAsync());
        }

        // GET: GameItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.GameItems
                .FirstOrDefaultAsync(m => m.GameItemId == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: GameItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameItemID,Name,Description,Price,Players,UserId,Age,Quantity,Image")] GameItem game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("GameItemList");
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.GameItems.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View("GameItemList");
        }

        // POST: GameItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameItemID,Name,Description,Price,Players,UserId,Age,Quantity,Image")] GameItem game)
        {
            if (id != game.GameItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (false)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View("GameItemList");
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.GameItems
                .FirstOrDefaultAsync(m => m.GameItemId == id);
            if (game == null)
            {
                return NotFound();
            }

            return View("GameItemList");
        }

        

        //TEST CODE END HERE
    }
}