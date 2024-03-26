using MEC.ControleRDO.Business;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace MEC.ControleRDO.Controllers
{
    [PaginaAdmin]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioBusiness usuarioBusiness)
        {
            _logger = logger;
            _usuarioBusiness = usuarioBusiness;
        }

        [HttpGet("IndexUsuario")]
        public IActionResult IndexUsuario()
        {
            var usuarioList = _usuarioBusiness.FindAll();
            return View(usuarioList);
        }

        [HttpGet("DetailsUsuario/{Id}")]
        public IActionResult DetailsUsuario(long Id)
        {
            var usuario = _usuarioBusiness.FindById(Id);

            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpGet("CreateUsuario")]
        public IActionResult CreateUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUsuarioConfirmed(UsuarioVO usuario)
        {
            if (usuario == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _usuarioBusiness.Create(usuario);

                return RedirectToAction(nameof(IndexUsuario));
            }
            else
            {
                return View("CreateUsuario", usuario);
            }
        }



        [HttpGet("EditUsuario/{Id}")]
        public IActionResult EditUsuario(long Id)
        {
            var usuario = _usuarioBusiness.FindById(Id);

            if (usuario == null)
                return NotFound();

            var usuarioSemSenha = new UsuarioSemSenhaVO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Login = usuario.Login,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };

            return View(usuarioSemSenha);
        }

        [HttpPost]
        public IActionResult EditUsuarioConfirmed(UsuarioSemSenhaVO usuarioSS)
        {
            if (ModelState.IsValid)
            {
                var usuarioOriginal = _usuarioBusiness.FindById(usuarioSS.Id);

                if (usuarioOriginal == null)
                    return NotFound();

                var usuario = new UsuarioVO()
                {
                    Id = usuarioSS.Id,
                    Nome = usuarioSS.Nome,
                    Login = usuarioSS.Login,
                    Email = usuarioSS.Email,
                    Perfil = usuarioSS.Perfil,
                    Senha = usuarioOriginal.Senha
                };

                _usuarioBusiness.Update(usuario);

                return RedirectToAction(nameof(IndexUsuario));
            }

            return View("EditUsuario", usuarioSS);
        }


        [HttpGet("DeleteUsuario/{Id}")]
        public IActionResult DeleteUsuario(long Id)
        {
            var usuario = _usuarioBusiness.FindById(Id);

            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpPost]
        public IActionResult DeleteUsuarioConfirmed(long Id)
        {
            try
            {
                _usuarioBusiness.Delete(Id);
                return RedirectToAction(nameof(IndexUsuario));
            }
            catch (DbUpdateException ex) when (ex.InnerException is MySqlException mySqlException)
            {
                // Tratar erro específico de violação de chave estrangeira
                ModelState.AddModelError("Error", "Não é possível excluir este registro devido a referências existentes em outras tabelas.");
                ViewData["ErrorMessage"] = "Não é possível excluir este registro devido a referências existentes em outras tabelas.";
            }
            catch (Exception ex)
            {
                // Tratar outros erros genéricos
                ModelState.AddModelError("Error", $"Ocorreu um erro ao excluir o registro: {ex.Message}");
                ViewData["ErrorMessage"] = "Ocorreu um erro ao excluir o registro.";
            }

            var usuario = _usuarioBusiness.FindById(Id);
            if (usuario == null) return NotFound();
            return View("DeleteUsuario", usuario);
        }
    }
}
