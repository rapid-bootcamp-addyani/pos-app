using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using AppContext = POS.Repository.AppContext;
using Microsoft.EntityFrameworkCore;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        private readonly SupplierService _serviceSupplier;
        private readonly CategoryService _serviceCategory;

        public ProductController(AppContext context)
        {
            _service = new ProductService(context);
        }

        [HttpGet]
        public ActionResult List()
        {
            var Data = _service.GetCategories();
            return View(Data);
        }

        
        [HttpGet]
        public IActionResult Details(int id)
        {
            var Data = _service.GetProductById(id);
            return View(Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Data = _service.GetProductById(id);
            return View(Data);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Data = _service.GetProductById(id);
            if (Data == null)
            {
                return Redirect("/");
            }

            _service.DeleteProduct(Data);
            return Redirect("/Product/List");
        }

        [HttpPost]
        public IActionResult Create([Bind("ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, RecorderLevel, Discountinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Create(new ProductEntity(request));
                return Redirect("/Product/List");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, RecorderLevel, Discountinued")] ProductModel request)
        {

            if (ModelState.IsValid)
            {
                ProductEntity product = new ProductEntity(request);
                product.Id = request.Id;
                _service.Update(product);
                return Redirect("/Product/List");
            }
            return View("Edit", request);
        }
    }
}
