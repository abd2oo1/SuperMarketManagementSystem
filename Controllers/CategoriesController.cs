using System.ComponentModel.Design;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
namespace WebApp.AddControllersWithViews
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var Categories = CategoriesRepository.GetCategories();
            return View("CategoriesIndex", Categories);
        }
        public IActionResult ShowCategory(int? id)
        {
            var NewCategory = new Category { CategoryId = id.HasValue ? id.Value : 0 };
            return View("ShowCategory", NewCategory);
        }
        public IActionResult EditCategory(int? id)
        {

            var NewCategory2 = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View("EditCategory", NewCategory2);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View("EditCategory", category);
        }
          public IActionResult AddCategory()
        {
            return View("AddCategory");
        }
        [HttpPost]
         public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View("AddCategory",category);
        }
        public IActionResult DeleteCategoryById(int CategoryId)
        {
            CategoriesRepository.DeleteCategory(CategoryId);
             return RedirectToAction(nameof(Index));
        }
    }
}