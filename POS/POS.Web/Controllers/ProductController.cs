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

        public ProductController(AppContext context)
        {
            _service = new ProductService(context);
        }

        [HttpGet]
        public ActionResult List()
        {
            var Data = _service.GetIncludeOrderDetails();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Data = _service.GetByIdIncludeOrderDetails(id);
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
            var Data = _service.GetById(id);
            return View(Data);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Redirect("/Product/List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, RecorderLevel, Discountinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Create(request);
                return Redirect("/Product/List");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, RecorderLevel, Discountinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Update(request);
                return Redirect("/Product/List");
            }
            return View("Edit", request);
        }
    }
}
