using MEC.ControleRDO.Business;
using MEC.ControleRDO.Data.VO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace MEC.ControleRDO.Controllers
{
    public class FiscalController : Controller
    {
        private readonly ILogger<FiscalController> _logger;
        private readonly IFiscalBusiness _fiscalBusiness;

        public FiscalController(ILogger<FiscalController> logger, IFiscalBusiness fiscalBusiness)
        {
            _logger = logger;
            _fiscalBusiness = fiscalBusiness;
        }

        [HttpGet("IndexFiscal")]
        public IActionResult IndexFiscal()
        {
            var fiscalList = _fiscalBusiness.FindAll();
            return View(fiscalList);
        }

        [HttpGet("DetailsFiscal/{Id}")]
        public IActionResult DetailsFiscal(long Id)
        {
            var fiscal = _fiscalBusiness.FindById(Id);

            if (fiscal == null) return NotFound();

            return View(fiscal);
        }

        [HttpGet("CreateFiscal")]
        public IActionResult CreateFiscal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFiscalConfirmed(FiscalVO fiscal)
        {
            if (fiscal == null) return BadRequest();

            _fiscalBusiness.Create(fiscal);

            return RedirectToAction(nameof(IndexFiscal));
        }



        [HttpGet("EditFiscal/{Id}")]
        public IActionResult EditFiscal(long Id)
        {
            var fiscal = _fiscalBusiness.FindById(Id);

            if (fiscal == null) return NotFound();

            return View(fiscal);
        }

        [HttpPost]
        public IActionResult EditFiscalConfirmed(FiscalVO fiscal)
        {
            if (fiscal == null) return BadRequest();

            _fiscalBusiness.Update(fiscal);

            return RedirectToAction(nameof(IndexFiscal));
        }


        [HttpGet("DeleteFiscal/{Id}")]
        public IActionResult DeleteFiscal(long Id)
        {
            var fiscal = _fiscalBusiness.FindById(Id);

            if (fiscal == null) return NotFound();

            return View(fiscal);
        }

        [HttpPost]
        public IActionResult DeleteFiscalConfirmed(long Id)
        {
            try
            {
                _fiscalBusiness.Delete(Id);
                return RedirectToAction(nameof(IndexFiscal));
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

            var fiscal = _fiscalBusiness.FindById(Id);
            if (fiscal == null) return NotFound();
            return View("DeleteFiscal", fiscal);
        }


    }
}
