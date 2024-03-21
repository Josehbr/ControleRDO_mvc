using MEC.ControleRDO.Business;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MEC.ControleRDO.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioBusiness _usuarioBusiness;
        public LoginController(ILogger<UsuarioController> logger, IUsuarioBusiness usuarioBusiness)
        {
            _logger = logger;
            _usuarioBusiness = usuarioBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioVO usuario = _usuarioBusiness.GetByLogin(loginModel.Login);
                    

                    if(usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MenssagemErro"] = $"senha incorreta";
                    }
                    
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MenssagemErro"] = $"Erro no login: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
