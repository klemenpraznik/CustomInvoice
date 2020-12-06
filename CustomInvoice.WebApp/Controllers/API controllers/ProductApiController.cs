using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using CustomInvoice.WebApp.Attributes;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomInvoice.WebApp.Controllers.API_controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ProductApiController(ApplicationDbContext db)
        {
            _context = db;
        }


        [HttpGet()]
        public ActionResult<Product> GetProducts()
        {
            List<Product> allProducts = _context.Products.ToList();
            foreach (var product in allProducts)
            {
                product.Category = _context.Categories.SingleOrDefault(p => p.Id == product.CategoryId);
                product.Partner = _context.Partners.SingleOrDefault(p => p.Id == product.PartnerId);
            }
            if (allProducts.Count() == 0) { return NoContent(); }

            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            Product selectedProduct = _context.Products.SingleOrDefault(p => p.Id == id);
            
            if (selectedProduct == null) //not found
            {
                return NotFound();
            }

            //selectedProduct.Category = _context.Categories.SingleOrDefault(p => p.Id == selectedProduct.CategoryId);
            //selectedProduct.Partner = _context.Partners.SingleOrDefault(p => p.Id == selectedProduct.PartnerId);

            return Ok(selectedProduct);
        }

        //[HttpPost()]
        //public ActionResult CreateProduct(Product Product)
        //{
        //    if (!ModelState.IsValid) { return BadRequest(); }
        //    Product newProduct = new Product();
        //    newProduct.Name = Product.Name;
        //    newProduct.Email = Product.Email;
        //    newProduct.PhoneNumber = Product.PhoneNumber;
        //    newProduct.StreetName = Product.StreetName;
        //    newProduct.StreetNumber = Product.StreetNumber;
        //    newProduct.PostNumber = Product.PostNumber;
        //    newProduct.City = Product.City;
        //    newProduct.Country = Product.Country;

        //    _context.Products.Add(newProduct);
        //    _context.SaveChanges();

        //    Product.Id = newProduct.Id;

        //    return Created("api/Product/" + newProduct.Id, Product);
        //}

        //[HttpPut("{id}")]
        //public ActionResult UpdateProduct(int id, Product Product)
        //{
        //    if (!ModelState.IsValid) { return BadRequest(); }

        //    Product ProductInDb = _context.Products.SingleOrDefault(p => p.Id == id);

        //    if (ProductInDb == null) { return NotFound(); }

        //    ProductInDb.Name = Product.Name;
        //    ProductInDb.Email = Product.Email;
        //    ProductInDb.PhoneNumber = Product.PhoneNumber;
        //    ProductInDb.StreetName = Product.StreetName;
        //    ProductInDb.StreetNumber = Product.StreetNumber;
        //    ProductInDb.PostNumber = Product.PostNumber;
        //    ProductInDb.City = Product.City;
        //    ProductInDb.Country = Product.Country;

        //    _context.SaveChanges();

        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            Product ProductInDb = _context.Products.SingleOrDefault(p => p.Id == id);

            if (ProductInDb == null) { return NotFound(); }

            _context.Products.Remove(ProductInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
