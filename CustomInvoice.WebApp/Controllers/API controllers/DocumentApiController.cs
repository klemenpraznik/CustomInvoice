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

        [HttpPost()]
        public ActionResult<Document> CreateDocument(Document document)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            Document newDocument = new Document();
            newDocument.ClientId = document.ClientId;

            //predračun
            newDocument.OfferDate = document.OfferDate;
            newDocument.OfferValidityDays = document.OfferValidityDays;
            newDocument.OfferDateOfOrder = document.OfferDateOfOrder;

            //račun
            newDocument.InvoiceDate = document.InvoiceDate;
            newDocument.InvoiceServiceFrom = document.InvoiceServiceFrom;
            newDocument.InvoiceServiceUntil = document.InvoiceServiceUntil;
            newDocument.InvoiceDateOfMaturity = document.InvoiceDateOfMaturity;
            newDocument.InvoiceDateOfOrder = document.InvoiceDateOfOrder;

            //dobavnica
            newDocument.DeliveryNoteDate = document.DeliveryNoteDate;

            //cene
            newDocument.TotalExcludingVAT = document.TotalExcludingVAT;
            newDocument.DiscountPercent = document.DiscountPercent;
            newDocument.DiscountAmount = document.DiscountAmount;
            newDocument.AmountExcludingVAT = document.AmountExcludingVAT;
            newDocument.AmountIncludingVAT = document.AmountIncludingVAT;

            _context.Documents.Add(newDocument);
            _context.SaveChanges();
            int newId = newDocument.Id;
            return Created("api/document/" + newId, newId);
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
