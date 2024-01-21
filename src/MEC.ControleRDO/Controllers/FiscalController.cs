using MEC.ControleRDO.Business;
using MEC.ControleRDO.Data.VO;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Index()
        {
            var fiscalList = _fiscalBusiness.FindAll();
            return View(fiscalList);
        }

        [HttpGet("{Id}")]
        public IActionResult Details(long Id)
        {
            var fiscal = _fiscalBusiness.FindById(Id);

            if (fiscal == null) return NotFound();

            return View(fiscal);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FiscalVO fiscal)
        {
            if (fiscal == null) return BadRequest();

            _fiscalBusiness.Create(fiscal);

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Edit(long Id)
        {
            var fiscal = _fiscalBusiness.FindById(Id);

            if (fiscal == null) return NotFound();

            return View(fiscal);
        }

        [HttpPost]
        public IActionResult Edit(FiscalVO fiscal)
        {
            if (fiscal == null) return BadRequest();

            _fiscalBusiness.Update(fiscal);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(long Id)
        {
            var fiscal = _fiscalBusiness.FindById(Id);

            if (fiscal == null) return NotFound();

            return View(fiscal);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(long Id)
        {
            _fiscalBusiness.Delete(Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
