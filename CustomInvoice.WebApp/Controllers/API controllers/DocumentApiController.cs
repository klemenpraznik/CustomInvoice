using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using CustomInvoice.WebApp.Attributes;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using CustomInvoice.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomInvoice.WebApp.Controllers.API_controllers
{
    [Route("api/document")]
    [ApiController]
    public class DocumentApiController : ControllerBase
    {
        private ApplicationDbContext _context;

        public DocumentApiController(ApplicationDbContext db)
        {
            _context = db;
        }


        [HttpGet()]
        public ActionResult<Document> GetDocuments()
        {
            
            List<Document> allProducts = _context.Documents.Include(p => p.Client).ToList();

            if (allProducts.Count() == 0) { return NoContent(); }

            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<Document> GetDocument(int id)
        {
            Document selectedDocument = _context.Documents.Include(p => p.Client).SingleOrDefault(p => p.Id == id);

            if (selectedDocument == null) //not found
            {
                return NotFound();
            }

            return Ok(selectedDocument);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDocument(int id)
        {
            Document selectedDocument = _context.Documents.Include(p => p.Client).SingleOrDefault(p => p.Id == id);

            if (selectedDocument == null) { return NotFound(); }

            _context.Documents.Remove(selectedDocument);
            _context.SaveChanges();

            return Ok();
        }
    }
} 
