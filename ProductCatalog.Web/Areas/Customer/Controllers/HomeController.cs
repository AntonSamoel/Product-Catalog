using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Core.Interfaces;
using ProductCatalog.Core.Models;
using System.Diagnostics;

namespace ProductCatalog.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var activeProducts = await _unitOfWork.Products.GetActiveProductsAsync();
            return View(activeProducts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _unitOfWork.Products.FindAsync(p=>p.Id == id,new string[] {"Category"});
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
