using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using CustomInvoice.WebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomInvoice.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController(ApplicationDbContext db)
        {
            _context = db;
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            foreach (var product in _context.Products.Include(c => c.Category).Include(p => p.Partner))
            {
                products.Add(product);
            }
            return products;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Details(int id)
        {
            var selectedProduct = _context.Products.SingleOrDefault(p => p.Id == id);
            selectedProduct.Partner = _context.Partners.SingleOrDefault(p => p.Id == selectedProduct.PartnerId);
            selectedProduct.Category = _context.Categories.SingleOrDefault(p => p.Id == selectedProduct.CategoryId);
            if (selectedProduct == null)
            {
                return NotFound();
            }
            

            return View(selectedProduct);
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductFormViewModel()
            {
                Product = product,
                CategoriesList = _context.Categories,
                PartnersList = _context.Partners
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            return View("Edit", new ProductFormViewModel() { CategoriesList = _context.Categories, PartnersList = _context.Partners });
        }

        //public ActionResult Delete(int id)
        //{
        //    Partner selectedPartner = GetPartners().SingleOrDefault(p => p.Id == id);
        //    if (selectedPartner == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Partners.Remove(selectedPartner);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Partner");
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProductFormViewModel productForm)
        {
            if (productForm.Product.Id == 0)
            {
                _context.Products.Add(productForm.Product);
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id == productForm.Product.Id);

                productInDb.Name = productForm.Product.Name;
                productInDb.ShortName = productForm.Product.ShortName;
                productInDb.Manufacturer = productForm.Product.Manufacturer;
                productInDb.PartnerId = productForm.Product.PartnerId;
                productInDb.CategoryId = productForm.Product.CategoryId;
                productInDb.WarrantyInMonths = productForm.Product.WarrantyInMonths;
                productInDb.Type = productForm.Product.Type;
                productInDb.UnitOfMeasure = productForm.Product.UnitOfMeasure;
                productInDb.PurchasePrice = productForm.Product.PurchasePrice;
                productInDb.SellingPrice = productForm.Product.SellingPrice;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

    }
}
