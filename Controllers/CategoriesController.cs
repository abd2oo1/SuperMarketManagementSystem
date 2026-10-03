using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models ; 
namespace WebApp.AddControllersWithViews
{
    public  class CategoriesController : Controller {
        public IActionResult Index ()
        {
            return View("CategoriesIndex");
        }
        public IActionResult ShowCategory(int? id)
        {
            var NewCategory = new Category {CategoryId = id.HasValue ? id.Value : 0 };
            return View("ShowCategory",NewCategory);
        }
    }
}