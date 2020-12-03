using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomInvoice.WebApp.Controllers.API_controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CategoryApiController(ApplicationDbContext db)
        {
            _context = db;
        }


        [HttpGet()]
        public ActionResult<Category> GetCategories()
        {
            List<Category> allCategories = _context.Categories.ToList();
            if (allCategories.Count() == 0) { return NoContent(); }

            return Ok(allCategories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            Category selectedCategory = _context.Categories.SingleOrDefault(p => p.Id == id);
            if (selectedCategory == null) //not found
            {
                return NotFound();
            }

            return Ok(selectedCategory);
        }

        [HttpPost()]
        public ActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            Category newCategory = new Category();
            newCategory.Name = category.Name;
            newCategory.Description = category.Description;

            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            category.Id = newCategory.Id;

            return Created("api/category/" + newCategory.Id, category);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, Category category)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            Category categoryInDb = _context.Categories.SingleOrDefault(p => p.Id == id);
            
            if (categoryInDb == null) { return NotFound(); }

            categoryInDb.Name = category.Name;
            categoryInDb.Description = category.Description;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            Category categoryInDb = _context.Categories.SingleOrDefault(p => p.Id == id);

            if (categoryInDb == null) { return NotFound(); }

            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
