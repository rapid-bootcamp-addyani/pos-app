using Microsoft.AspNetCore.Mvc;
using POS.Service;
using POS.Repository;
using AppContext = POS.Repository.AppContext;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Update(int id)
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
            _service.SaveChanges();
            return Redirect("/Category/List");
        }

        [HttpPost]
        public IActionResult Create([Bind("CategoryName, Description")] Category request)
        {
            _service.Create(request);
            _service.SaveChanges();

            return Redirect("/Category/List");
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CategoryName, Description")] Category request)
        {
            _service.Update(request);
            _service.SaveChanges();

            return Redirect("/Category/List");
        }
    }
}
