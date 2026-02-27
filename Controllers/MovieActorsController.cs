using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cprestegard_sp2026_assignment3.Data;
using cprestegard_sp2026_assignment3.Models;

namespace cprestegard_sp2026_assignment3.Controllers
{
    public class MovieActorsController : Controller
    {
        private readonly AppDbContext _context;

        public MovieActorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MovieActors
        public async Task<IActionResult> Index()
        {
            var movieActors = await _context.MovieActors
                .Include(ma => ma.Movie)
                .Include(ma => ma.Actor)
                .ToListAsync();
            return View(movieActors);
        }

        // GET: MovieActors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MovieActors
                .Include(ma => ma.Movie)
                .Include(ma => ma.Actor)
                .FirstOrDefaultAsync(m => m.MovieActorId == id);
            if (movieActor == null)
            {
                return NotFound();
            }

            return View(movieActor);
        }

        // GET: MovieActors/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "Title");
            ViewData["ActorId"] = new SelectList(_context.Actors, "ActorId", "Name");
            return View();
        }

        // POST: MovieActors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieActorId,MovieId,ActorId,CharacterName")] MovieActor movieActor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieActor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "Title", movieActor.MovieId);
            ViewData["ActorId"] = new SelectList(_context.Actors, "ActorId", "Name", movieActor.ActorId);
            return View(movieActor);
        }

        // GET: MovieActors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MovieActors.FindAsync(id);
            if (movieActor == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "Title", movieActor.MovieId);
            ViewData["ActorId"] = new SelectList(_context.Actors, "ActorId", "Name", movieActor.ActorId);
            return View(movieActor);
        }

        // POST: MovieActors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieActorId,MovieId,ActorId,CharacterName")] MovieActor movieActor)
        {
            if (id != movieActor.MovieActorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieActor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieActorExists(movieActor.MovieActorId))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "Title", movieActor.MovieId);
            ViewData["ActorId"] = new SelectList(_context.Actors, "ActorId", "Name", movieActor.ActorId);
            return View(movieActor);
        }

        // GET: MovieActors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieActor = await _context.MovieActors
                .Include(ma => ma.Movie)
                .Include(ma => ma.Actor)
                .FirstOrDefaultAsync(m => m.MovieActorId == id);
            if (movieActor == null)
            {
                return NotFound();
            }

            return View(movieActor);
        }

        // POST: MovieActors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieActor = await _context.MovieActors.FindAsync(id);
            if (movieActor != null)
            {
                _context.MovieActors.Remove(movieActor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieActorExists(int id)
        {
            return _context.MovieActors.Any(e => e.MovieActorId == id);
        }
    }
}
