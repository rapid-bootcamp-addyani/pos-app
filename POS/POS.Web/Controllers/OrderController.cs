using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;
using AppContext = POS.Repository.AppContext;

namespace POS.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _service;

        public OrderController(AppContext context)
        {
            _service = new OrderService(context);
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
            return Redirect("/Order/List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerId, EmployeeId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Create(request);
                return Redirect("/Order/List");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CustomerId, EmployeeId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Update(request);
                return Redirect("/Order/List");
            }
            return View("Edit", request);
        }
    }
}
