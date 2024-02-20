﻿using MEC.ControleRDO.Business;
using MEC.ControleRDO.Data.VO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace MEC.ControleRDO.Controllers
{
    public class RdoController : Controller
    {
        private readonly ILogger<RdoController> _logger;
        private readonly IRdoBusiness _rdoBusiness;
        private readonly IObraBusiness _obraBusiness;

        public RdoController(ILogger<RdoController> logger, IRdoBusiness rdoBusiness, IObraBusiness obraBusiness)
        {
            _logger = logger;
            _rdoBusiness = rdoBusiness;
            _obraBusiness = obraBusiness;
        }

        [HttpGet("IndexRdo")]
        public IActionResult IndexRdo()
        {
            var rdolist = _rdoBusiness.FindAll();
            return View(rdolist);
        }
        [HttpGet("DetailsRdo/{Id}")]
        public IActionResult DetailsRdo(long Id)
        {
            var rdo = _rdoBusiness.FindById(Id);

            if (rdo == null)
            {
                return NotFound();
            }

            return View(rdo);
        }



        [HttpGet("CreateRdo")]
        public IActionResult CreateRdo(RdoVO rdo)
        {
            var listaObra = _obraBusiness.FindAll();
            rdo.ListaObra = listaObra;
            return View(rdo);
        }

        [HttpPost]
        public IActionResult CreateRdoConfirmed(RdoVO rdo)
        {
            if (rdo == null) return BadRequest();
            _rdoBusiness.Create(rdo);
            return RedirectToAction(nameof(IndexRdo));
        }

        [HttpGet("EditRdo/{Id}")]
        public IActionResult EditRdo(long Id)
        {
            var rdo = _rdoBusiness.FindById(Id);

            if (rdo == null) return NotFound();

            var listaobra = _obraBusiness.FindAll();
            rdo.ListaObra = listaobra;

            return View(rdo);
        }

        [HttpPost]
        public IActionResult EditRdoConfirmed(RdoVO rdo)
        {
            if (rdo == null) return BadRequest();

            _rdoBusiness.Update(rdo);

            return RedirectToAction(nameof(IndexRdo));
        }
        [HttpGet("DeleteRdo/{Id}")]
        public IActionResult DeleteRdo(long Id)
        {
            var rdo = _rdoBusiness.FindById(Id);

            if (rdo == null) return NotFound();

            return View(rdo);
        }
        [HttpPost]
        public IActionResult DeleteRdoConfirmed(long Id)
        {
            try
            {
                _rdoBusiness.Delete(Id);
                return RedirectToAction(nameof(IndexRdo));
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

            var rdo = _rdoBusiness.FindById(Id);
            if (rdo == null) return NotFound();
            return View("DeleteRdo", rdo);
        }
    }
}
