using MEC.ControleRDO.Business;
using MEC.ControleRDO.Data.VO;
using Microsoft.AspNetCore.Mvc;

namespace MEC.ControleRDO.Controllers
{
    public class RdoController : Controller
    {
        private readonly ILogger<RdoController> _logger;
        private readonly IRdoBusiness _rdoBusiness;

        public RdoController(ILogger<RdoController> logger, IRdoBusiness rdoBusiness)
        {
            _logger = logger;
            _rdoBusiness = rdoBusiness;
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

            if (rdo == null) return NotFound();

            return View(rdo);
        }


        [HttpGet("CreateRdp/{Id}")]
        public IActionResult CreateRdo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRdoConfirmed(RdoVO rdo)
        {
            if (rdo == null) return BadRequest();
            _rdoBusiness.Create(rdo);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("EditRdo/{Id}")]
        public IActionResult EditRdo(long Id)
        {
            var rdo = _rdoBusiness.FindById(Id);
            if (rdo == null) return NotFound();

            return View(rdo);
        }

        [HttpPost]
        public IActionResult EditRdoConfirmed(RdoVO rdo)
        {
            if (rdo == null) return BadRequest();

            _rdoBusiness.Update(rdo);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet("DeleteRdo/{Id}")]
        public IActionResult DeleteRdo(long Id)
        {
            var rdo = _rdoBusiness.FindById(Id);

            if (rdo == null) return NotFound();

            return View(rdo);
        }
        [HttpPost]
        public IActionResult DeleteRdpConfirmed(long Id)
        {
            _rdoBusiness.Delete(Id);

            return RedirectToAction(nameof(IndexRdo));
        }
    }
}
