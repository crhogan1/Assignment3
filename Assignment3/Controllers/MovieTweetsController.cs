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
    public class MovieTweetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieTweetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieTweets
        public async Task<IActionResult> Index()
        {
              return View(await _context.MovieTweets.ToListAsync());
        }

        // GET: MovieTweets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovieTweets == null)
            {
                return NotFound();
            }

            var movieTweets = await _context.MovieTweets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieTweets == null)
            {
                return NotFound();
            }

            return View(movieTweets);
        }

        // GET: MovieTweets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieTweets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tweet,Sentiment")] MovieTweets movieTweets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieTweets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieTweets);
        }

        // GET: MovieTweets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovieTweets == null)
            {
                return NotFound();
            }

            var movieTweets = await _context.MovieTweets.FindAsync(id);
            if (movieTweets == null)
            {
                return NotFound();
            }
            return View(movieTweets);
        }

        // POST: MovieTweets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tweet,Sentiment")] MovieTweets movieTweets)
        {
            if (id != movieTweets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieTweets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieTweetsExists(movieTweets.Id))
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
            return View(movieTweets);
        }

        // GET: MovieTweets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovieTweets == null)
            {
                return NotFound();
            }

            var movieTweets = await _context.MovieTweets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieTweets == null)
            {
                return NotFound();
            }

            return View(movieTweets);
        }

        // POST: MovieTweets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovieTweets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MovieTweets'  is null.");
            }
            var movieTweets = await _context.MovieTweets.FindAsync(id);
            if (movieTweets != null)
            {
                _context.MovieTweets.Remove(movieTweets);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieTweetsExists(int id)
        {
          return _context.MovieTweets.Any(e => e.Id == id);
        }
    }
}
