using GigHub.Data;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace GigHub.Controllers
{
    
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController(ApplicationDbContext context)
        {
            _context = context; 
        }
        [Authorize]
        public IActionResult Create()
        {
            IEnumerable<Genre> genres=_context.Genres;
            ViewBag.Genres = new SelectList(genres, "Id", "Name");
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(GigFormViewModel model) 
        {
            var artist = _context.Users.Single(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var genre = _context.Genres.Single(u => u.Id == model.Genre);
            var gig = new Gig
            {
                Artist = artist,
                DateTime = DateTime.Parse(string.Format("{0} {1}", model.Date, model.Time)),
                Genre = genre,
                Venue = model.Venue,
            };
            _context.Add(gig);
            _context.SaveChanges(); 
            return RedirectToAction("Index","Home");
        }
    }
}
