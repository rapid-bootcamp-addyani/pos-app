using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;
using AppContext = POS.Repository.AppContext;

namespace POS.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _service;

        public CustomerController(AppContext context)
        {
            _service = new CustomerService(context);
        }

        [HttpGet]
        public ActionResult List()
        {
            var Data = _service.GetIncludeOrders();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Data = _service.GetByIdIncludeOrders(id);
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
            return Redirect("/Customer/List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Create(request);
                return Redirect("/Customer/List");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Update(request);
                return Redirect("/Customer/List");
            }
            return View("Edit", request);
        }
    }
}
