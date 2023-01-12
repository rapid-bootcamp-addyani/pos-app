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
            var Data = _service.GetCategories();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Data = _service.GetCategoryById(id);
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
            var Data = _service.GetCategoryById(id);
            return View(Data);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Data = _service.GetCategoryById(id);
            if (Data == null)
            {
                return Redirect("/");
            }

            _service.DeleteCategory(Data);
            return Redirect("/Category/List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryName, Description")] CategoryModel request)
        {
            if(ModelState.IsValid)
            {
                _service.Create(new CategoryEntity(request));
                return Redirect("/Category/List");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CategoryName, Description")] CategoryModel request)
        {
            if (ModelState.IsValid)
            {
                CategoryEntity category = new CategoryEntity(request);
                category.Id= request.Id;
                _service.Update(category);
                return Redirect("/Category/List");
            }
            return View("Edit", request);
        }
    }
}
