using Microsoft.AspNetCore.Mvc;

namespace Villa_Project.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
