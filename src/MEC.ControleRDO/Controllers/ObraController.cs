using MEC.ControleRDO.Business;
using MEC.ControleRDO.Data.VO;
using Microsoft.AspNetCore.Mvc;

namespace MEC.ControleRDO.Controllers
{
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
        public IActionResult CreateObra(ObraVO obra)
        {
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
            _obraBusiness.Delete(Id);

            return RedirectToAction(nameof(IndexObra));
        }
    }
}
