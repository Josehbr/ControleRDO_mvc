using MEC.ControleRDO.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MEC.ControleRDO.Controllers
{
    [PaginaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();  
        }
    }
}
