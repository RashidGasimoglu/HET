using HET.BLL.Services.Interfaces;
using HET.DAL.Models;
using HET.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace HET.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseEnergyService _houseEnergyService;
        public HomeController(IHouseEnergyService houseEnergyService)
        {
            _houseEnergyService = houseEnergyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.InsulationType = new SelectList(new List<string> { "High", "Medium", "Medium" });
            ViewBag.HeatingSystemType = new SelectList(new List<string> { "Gas", "Electric", "Heat Pump" });
            ViewBag.CoolingSystemType = new SelectList(new List<string> { "Central AC", "Window Units"});
            ViewBag.LightingType = new SelectList(new List<string> { "LED", "CFL", "Incandescent" });
            return View(new HouseEnergyModel());
        }
        [HttpPost]
        public IActionResult CalculateEnergyConsumption(HouseEnergyModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _houseEnergyService.CalculateEnergyConsumption(model);
                model.EnergyConsumption = result;
                return RedirectToAction("Result",model);
            }
            ViewBag.InsulationType = new SelectList(new List<string> { "High", "Medium", "Medium" });
            ViewBag.HeatingSystemType = new SelectList(new List<string> { "Gas", "Electric", "Heat Pump" });
            ViewBag.CoolingSystemType = new SelectList(new List<string> { "Central AC", "Window Units" });
            ViewBag.LightingType = new SelectList(new List<string> { "LED", "CFL", "Incandescent" });
            return View("Index", model);
        }

        public IActionResult Result (HouseEnergyModel model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
