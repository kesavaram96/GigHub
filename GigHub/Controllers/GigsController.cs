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
        [ValidateAntiForgeryToken]
        public IActionResult Create(GigFormViewModel model) 
        {
            if (!ModelState.IsValid) 
            {
                //model.Genre = _context.Genres.ToList();
                return View(model);
            }
            
        
            var gig = new Gig
            {
                ArtistId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                DateTime = model.GetDateTime(),
                GenreId = model.Genre,
                Venue = model.Venue,
            };

            _context.Add(gig);
            _context.SaveChanges(); 
            return RedirectToAction("Index","Home");
        }
    }
}
