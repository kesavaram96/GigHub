using Microsoft.AspNetCore.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
