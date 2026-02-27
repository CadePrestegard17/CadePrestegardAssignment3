using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cprestegard_sp2026_assignment3.Data;
using cprestegard_sp2026_assignment3.Models;
using cprestegard_sp2026_assignment3.Services;
using cprestegard_sp2026_assignment3.ViewModels;

namespace cprestegard_sp2026_assignment3.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly RedditService _redditService;
        private readonly HuggingFaceSentimentService _sentimentService;

        public MoviesController(AppDbContext context, RedditService redditService, HuggingFaceSentimentService sentimentService)
        {
            _context = context;
            _redditService = redditService;
            _sentimentService = sentimentService;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.MovieActors)
                .ThenInclude(ma => ma.Actor)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            var viewModel = new MovieDetailsViewModel
            {
                Movie = movie
            };

            // Fetch Reddit comments
            var searchQuery = $"{movie.Title} movie";
            var comments = await _redditService.SearchRedditCommentsAsync(searchQuery);

            // Analyze sentiment for each comment
            var commentSentiments = new List<CommentSentimentRow>();
            var signedScores = new List<double>();

            foreach (var comment in comments)
            {
                var truncatedComment = TruncateToMaxLength(comment, 200);
                var sentiment = await _sentimentService.AnalyzeSentimentAsync(comment);

                commentSentiments.Add(new CommentSentimentRow
                {
                    CommentText = truncatedComment,
                    SentimentDisplay = sentiment.GetDisplayString()
                });

                signedScores.Add(sentiment.GetSignedScore());
            }

            viewModel.CommentSentiments = commentSentiments;

            // Calculate overall sentiment
            if (signedScores.Count > 0)
            {
                var avgScore = signedScores.Average();
                viewModel.OverallSentimentData = new OverallSentiment
                {
                    Label = LabelFromScore(avgScore),
                    AverageScore = avgScore
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

        private string LabelFromScore(double score)
        {
            if (score > 0.1)
                return "POSITIVE";
            else if (score < -0.1)
                return "NEGATIVE";
            else
                return "NEUTRAL";
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Title,ImdbUrl,Genre,ReleaseYear,PosterUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Title,ImdbUrl,Genre,ReleaseYear,PosterUrl")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
