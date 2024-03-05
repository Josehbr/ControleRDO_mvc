using Microsoft.AspNetCore.Mvc;

namespace MEC.ControleRDO.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
