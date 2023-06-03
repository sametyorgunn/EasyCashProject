using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
