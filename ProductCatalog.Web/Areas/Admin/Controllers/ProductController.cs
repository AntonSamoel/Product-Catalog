using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using ProductCatalog.Core.Interfaces;
using ProductCatalog.Core.Models;
using ProductCatalog.Core.ViewModels;


namespace ProductCatalog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        #endregion

        #region Constructor
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion


        #region Actions

        public  IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            ProductViewModel productVM = new();

            var categories = await _unitOfWork.Categories.GetAllAsync();

            // Intialize the Dropdown list for categories
            productVM.CategoryList = categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            });

            // Create New Product Case
            if (id == 0 || id is null)
            {
                return View(productVM);
            }
            // Update Existing Product Case
            else
            {
                var product = await _unitOfWork.Products.GetByIdAsync(id ?? 0);

                // TO BE DONE (MAPPING)
                productVM = _mapper.Map<ProductViewModel>(product);


                productVM.CategoryList = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                });

                return View(productVM);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ProductViewModel productVM)
        {
           if(ModelState.IsValid)
           {
                var product = _mapper.Map<Product>(productVM);

                if (productVM.Id == 0)
                {
                    await _unitOfWork.Products.AddAsync(product);
                     _unitOfWork.Save();
                    TempData["sucess"] = "Product Added Successfully";

                }
                else
                {
                    _unitOfWork.Products.Update(product);
                    _unitOfWork.Save();
                    TempData["sucess"] = "Product Updated Successfully";
                }
           }

            return RedirectToAction("Index");
        }

        #endregion


        #region API Endpoints For DataTable

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Using Eager Loading To Get Product and Category Together
            string[] includes = { "Category" };
            var productList = await _unitOfWork.Products.FindAllAsync(p => p.Id != 0, includes);
            return Json(new { data = productList });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id ?? 0);

            if (product is null)
            {
                return Json(new { success = false, message = "Id NOT FOUND" });
            }

            _unitOfWork.Products.Remove(product);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Product Deleted Successfully" });
        }
        #endregion

    }
}
