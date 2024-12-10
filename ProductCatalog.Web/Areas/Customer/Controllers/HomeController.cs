using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Core.Interfaces;
using ProductCatalog.Core.Models;
using System.Diagnostics;

namespace ProductCatalog.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var currentDate = DateTime.Now;
            var activeProducts = await _unitOfWork.Products.FindAllAsync(p => currentDate >= p.StartDate && currentDate <= p.StartDate.AddDays(p.DurationInDays), new string[] { "Category", "ApplicationUser" });
            return View(activeProducts);
        }  
        public async Task<IActionResult> FilterByCategory(string category)
        {
            var currentDate = DateTime.Now;
            var activeProducts = await _unitOfWork.Products.FindAllAsync(p => currentDate >= p.StartDate && currentDate <= p.StartDate.AddDays(p.DurationInDays), new string[] { "Category", "ApplicationUser" });

            if (category == "all")
                return View("Index", activeProducts);

            var activeProductsFiltered = activeProducts.Where(p=>p.Category.Name== category);

            return View("Index", activeProductsFiltered);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _unitOfWork.Products.FindAsync(p=>p.Id == id,new string[] {"Category", "ApplicationUser" });

            if(product is null)
                return View("NotFound");
            return View(product);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
