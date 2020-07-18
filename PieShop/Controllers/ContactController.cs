using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PieShop.Controllers
{
    public class ContactController : Controller
    {
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)]

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
