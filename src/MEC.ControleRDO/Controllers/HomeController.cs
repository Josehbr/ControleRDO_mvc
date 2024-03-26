﻿using MEC.ControleRDO.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MEC.ControleRDO.Controllers
{
    [PaginaUsuarioLogado]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
