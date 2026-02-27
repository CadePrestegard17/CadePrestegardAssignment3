using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cprestegard_sp2026_assignment3.Data;
using cprestegard_sp2026_assignment3.Models;
using cprestegard_sp2026_assignment3.Services;
using cprestegard_sp2026_assignment3.ViewModels;

namespace cprestegard_sp2026_assignment3.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly RedditService _redditService;
        private readonly VaderSentimentService _vaderSentimentService;

        public ActorsController(AppDbContext context, RedditService redditService, VaderSentimentService vaderSentimentService)
        {
            _context = context;
            _redditService = redditService;
            _vaderSentimentService = vaderSentimentService;
        }

        // GET: Actors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actors.ToListAsync());
        }

        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors
                .Include(a => a.MovieActors)
                .ThenInclude(ma => ma.Movie)
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (actor == null)
            {
                return NotFound();
            }

            var viewModel = new ActorDetailsViewModel
            {
                Actor = actor
            };

            // Fetch Reddit comments for the actor
            var searchQuery = $"{actor.Name} actor";
            var comments = await _redditService.SearchRedditCommentsAsync(searchQuery);

            // Analyze sentiment for each comment using VADER
            var commentSentiments = new List<CommentSentimentRow>();
            var compoundScores = new List<double>();

            foreach (var comment in comments)
            {
                var truncatedComment = TruncateToMaxLength(comment, 200);
                var sentiment = _vaderSentimentService.AnalyzeSentiment(comment);

                commentSentiments.Add(new CommentSentimentRow
                {
                    CommentText = truncatedComment,
                    SentimentDisplay = sentiment.GetDisplayString()
                });

                compoundScores.Add(sentiment.GetSignedCompound());
            }

            viewModel.CommentSentiments = commentSentiments;

            // Calculate overall sentiment
            if (compoundScores.Count > 0)
            {
                var avgCompound = compoundScores.Average();
                viewModel.OverallSentimentData = new OverallActorSentiment
                {
                    Label = LabelFromVaderCompound(avgCompound),
                    AverageCompound = avgCompound
                };
            }

            return View(viewModel);
        }

        private string TruncateToMaxLength(string text, int maxLen)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= maxLen)
                return text;

            return text.Substring(0, maxLen) + "...";
        }

        private string LabelFromVaderCompound(double compound)
        {
            if (compound >= 0.05)
                return "POSITIVE";
            else if (compound <= -0.05)
                return "NEGATIVE";
            else
                return "NEUTRAL";
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorId,Name,Gender,Age,ImdbUrl,PhotoUrl")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorId,Name,Gender,Age,ImdbUrl,PhotoUrl")] Actor actor)
        {
            if (id != actor.ActorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.ActorId))
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
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.ActorId == id);
        }
    }
}
