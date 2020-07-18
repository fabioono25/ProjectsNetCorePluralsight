using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PieShop.Models;
using PieShop.ViewModels;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILog _log;
        private readonly ILogger<PieController> _logger;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository, ILog log, ILogger<PieController> logger)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _log = log;
            _logger = logger;
        }

        public ViewResult List(string category)
        {
            _logger.LogError("adsasdad");
            _log.LogException("an error ocurred");

            ViewBag.CurrentCategory = "Cheese cakes";

            IEnumerable<Pie> pies;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.Pies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.Pies.Where(p => p.Category.CategoryName == category)
                   .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);

            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
