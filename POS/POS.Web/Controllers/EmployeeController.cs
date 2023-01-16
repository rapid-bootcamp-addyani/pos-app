using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;
using AppContext = POS.Repository.AppContext;

namespace POS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service;

        public EmployeeController(AppContext context)
        {
            _service = new EmployeeService(context);
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
        public IActionResult CreateModal()
        {
            return PartialView("_Create");
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
            return Redirect("/Employee/List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportTo")] EmployeeModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Create(request);
                return Redirect("/Employee/List");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportTo")] EmployeeModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Update(request);
                return Redirect("/Employee/List");
            }
            return View("Edit", request);
        }
    }
}
