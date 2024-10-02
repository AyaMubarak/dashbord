using Microsoft.AspNetCore.Mvc;

namespace Landing.PL.Areas.Dashbord.Controllers
{
    [Area("Dashbord")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
