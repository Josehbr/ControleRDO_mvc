using MEC.ControleRDO.Business;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace MEC.ControleRDO.Controllers
{
    [PaginaUsuarioLogado]
    public class ObraController : Controller
    {
        private readonly ILogger<ObraController> _logger;
        private readonly IObraBusiness _obraBusiness;
        private readonly IFiscalBusiness _fiscalBusiness;

        public ObraController(ILogger<ObraController> logger, IObraBusiness obraBusiness, IFiscalBusiness fiscalBusiness)
        {
            _logger = logger;
            _obraBusiness = obraBusiness;
            _fiscalBusiness = fiscalBusiness;
        }

        [HttpGet("IndexObra")]
        public IActionResult IndexObra()
        {
            var obraList = _obraBusiness.FindAll();
            return View(obraList);
        }

        [HttpGet("DetailsObra/{Id}")]
        public IActionResult DetailsObra(long Id)
        {
            var obra = _obraBusiness.FindById(Id);

            if (obra == null) return NotFound();

            return View(obra);
        }

        [HttpGet("CreateObra")]
        public IActionResult CreateObra()
        {
            var obra = new ObraVO();
            var listaDeFiscais = _fiscalBusiness.FindAll();
            obra.ListaDeFiscais = listaDeFiscais;

            return View(obra);
        }

        [HttpPost]
        public IActionResult CreateObraConfirmed(ObraVO obra)
        {
            if (obra == null) return BadRequest();

            _obraBusiness.Create(obra);

            return RedirectToAction(nameof(IndexObra));
        }

        [HttpGet("EditObra/{Id}")]
        public IActionResult EditObra(long Id)
        {
            var obra = _obraBusiness.FindById(Id);

            if (obra == null) return NotFound();

            var listaDeFiscais = _fiscalBusiness.FindAll();
            obra.ListaDeFiscais = listaDeFiscais;

            return View(obra);
        }

        [HttpPost]
        public IActionResult EditObraConfirmed(ObraVO obra)
        {
            if (obra == null) return BadRequest();

            _obraBusiness.Update(obra);

            return RedirectToAction(nameof(IndexObra));
        }

        [HttpGet("DeleteObra/{Id}")]
        public IActionResult DeleteObra(long Id)
        {
            var obra = _obraBusiness.FindById(Id);

            if (obra == null) return NotFound();

            return View(obra);
        }

        [HttpPost]
        public IActionResult DeleteObraConfirmed(long Id)
        {
            try
            {
                _obraBusiness.Delete(Id);
                return RedirectToAction(nameof(IndexObra));
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

            var obra = _obraBusiness.FindById(Id);
            if (obra == null) return NotFound();
            return View("DeleteObra", obra);
        }
    }
}
