using Microsoft.AspNetCore.Mvc;
using POS.Service;
using POS.Repository;
using AppContext = POS.Repository.AppContext;
using Microsoft.EntityFrameworkCore;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;

        public CategoryController(AppContext context)
        {
            _service = new CategoryService(context);
        }

        [HttpGet]
        public ActionResult List()
        {
            var Data = _service.GetIncludeProducts();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Data = _service.GetByIdIncludeProducts(id);
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
            return Redirect("/Category/List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryName, Description")] CategoryModel request)
        {
            if(ModelState.IsValid)
            {
                _service.Create(request);
                return Redirect("/Category/List");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CategoryName, Description")] CategoryModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Update(request);
                return Redirect("/Category/List");
            }
            return View("Edit", request);
        }
    }
}
