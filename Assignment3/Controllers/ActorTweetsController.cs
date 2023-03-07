using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment3.Data;
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class ActorTweetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorTweetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActorTweets
        public async Task<IActionResult> Index()
        {
              return View(await _context.ActorTweets.ToListAsync());
        }

        // GET: ActorTweets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ActorTweets == null)
            {
                return NotFound();
            }

            var actorTweets = await _context.ActorTweets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (actorTweets == null)
            {
                return NotFound();
            }

            return View(actorTweets);
        }

        // GET: ActorTweets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActorTweets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Tweet,Sentiment")] ActorTweets actorTweets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actorTweets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actorTweets);
        }

        // GET: ActorTweets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ActorTweets == null)
            {
                return NotFound();
            }

            var actorTweets = await _context.ActorTweets.FindAsync(id);
            if (actorTweets == null)
            {
                return NotFound();
            }
            return View(actorTweets);
        }

        // POST: ActorTweets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Tweet,Sentiment")] ActorTweets actorTweets)
        {
            if (id != actorTweets.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actorTweets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorTweetsExists(actorTweets.ID))
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
            return View(actorTweets);
        }

        // GET: ActorTweets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ActorTweets == null)
            {
                return NotFound();
            }

            var actorTweets = await _context.ActorTweets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (actorTweets == null)
            {
                return NotFound();
            }

            return View(actorTweets);
        }

        // POST: ActorTweets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ActorTweets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ActorTweets'  is null.");
            }
            var actorTweets = await _context.ActorTweets.FindAsync(id);
            if (actorTweets != null)
            {
                _context.ActorTweets.Remove(actorTweets);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorTweetsExists(int id)
        {
          return _context.ActorTweets.Any(e => e.ID == id);
        }
    }
}
