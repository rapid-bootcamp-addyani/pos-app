using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;
using AppContext = POS.Repository.AppContext;

namespace POS.Web.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly OrderDetailService _service;

        public OrderDetailController(AppContext context)
        {
            _service = new OrderDetailService(context);
        }

        [HttpGet]
        public ActionResult List()
        {
            var Data = _service.GetAll();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Data = _service.GetById(id);
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
            return Redirect("/OrderDetail/List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OrderId, ProductId, UnitPrice, Quantity, Discount")] OrderDetailModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Create(request);
                return Redirect("/OrderDetail/List");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, OrderId, ProductId, UnitPrice, Quantity, Discount")] OrderDetailModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Update(request);
                return Redirect("/OrderDetail/List");
            }
            return View("Edit", request);
        }
    }
}
