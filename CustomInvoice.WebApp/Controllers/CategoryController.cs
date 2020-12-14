using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using CustomInvoice.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomInvoice.WebApp.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext db)
        {
            _context = db;
        }

        public List<Category> GetCategories()
        {
            var categories = new List<Category>();
            foreach (var category in _context.Categories)
            {
                categories.Add(category);
            }
            return categories;
        }

        // GET: PartnerController
        public ActionResult Index()
        {
            return View("Index", GetCategories());
        }


        
        public ActionResult Details(int id)
        {
            Category selectedCategory = GetCategories().SingleOrDefault(p => p.Id == id);
            if (selectedCategory == null)
            {
                return View("ErrorPage", id);
            }

            return View(selectedCategory);
        }

        public ActionResult Edit(int id)
        {
            CategoryFormViewModel viewModel = new CategoryFormViewModel();
            viewModel.Id = id;
            viewModel.Category = GetCategories().SingleOrDefault(p => p.Id == id);
            if (viewModel.Category == null)
            {
                return View("ErrorPage", id);
            }

            return View(viewModel);
        }

        public ActionResult New()
        {
            return View("Edit", new CategoryFormViewModel());
        }

        public ActionResult Delete(int id)
        {
            Category selectedCategory = GetCategories().SingleOrDefault(p => p.Id == id);
            if (selectedCategory == null)
            {
                return View("ErrorPage", id);
            }
            _context.Categories.Remove(selectedCategory);
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CategoryFormViewModel categoryForm)
        {
            if (categoryForm.Id == 0)
            {
                _context.Categories.Add(categoryForm.Category);
            }
            else
            {
                var categoryInDb = _context.Categories.Single(p => p.Id == categoryForm.Id);

                categoryInDb.Name = categoryForm.Category.Name;
                categoryInDb.Description = categoryForm.Category.Description;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

    }
}
