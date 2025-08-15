using Microsoft.AspNetCore.Mvc;

namespace Villa_Project.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
