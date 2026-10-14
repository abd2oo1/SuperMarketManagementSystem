using System.ComponentModel.Design;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;
namespace WebApp.AddControllersWithViews
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var Product = ProductsRepository.GetProducts(LoadCatogary:true);
            return View("index",Product);
        }
        public IActionResult Add()
        {
            var product = new ProductViewModel
            {
                Categories = CategoriesRepository.GetCategories()
                
            };
            return View("Add",product);
        }
         [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.Categories= CategoriesRepository.GetCategories();
          
             
            return View("Add",productViewModel);
        }
          public IActionResult Edit(int id)
        {
            var product = new ProductViewModel
            {
                Product = ProductsRepository.GetProductById(id) ?? new Product(),
                Categories = CategoriesRepository.GetCategories()
                
            };
            return View("Edit",product);
        }
        [HttpPost]
           public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.Product.ProductId,productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
               productViewModel.Categories= CategoriesRepository.GetCategories();
          
             
            return View("Edit",productViewModel);
        }
        public IActionResult Delete(int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}