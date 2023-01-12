using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using AppContext = POS.Repository.AppContext;
using Microsoft.EntityFrameworkCore;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierService _service;

        public SupplierController(AppContext context)
        {
            _service = new SupplierService(context);
        }
        
        [HttpGet]
        public ActionResult List()
        {
            var Data = _service.GetSupplierWithProduct();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Data = _service.GetSupplierByIdWithProduct(id);
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
            var Data = _service.GetSupplierById(id);
            return View(Data);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Data = _service.GetSupplierById(id);
            if (Data == null)
            {
                return Redirect("/");
            }

            _service.DeleteSupplier(Data);
            return Redirect("/Supplier/List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, Homepage")] SupplierModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Create(new SupplierEntity(request));
                return Redirect("/Supplier/List");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, Homepage")] SupplierModel request)
        {
            if (ModelState.IsValid)
            {
                SupplierEntity supplier = new SupplierEntity(request);
                supplier.Id = request.Id;
                _service.Update(supplier);
                return Redirect("/Supplier/List");
            }
            return View("Edit", request);
        }
    }
}
