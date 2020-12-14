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

        [HttpPut("{id}")]
        public ActionResult<Document> UpdateDocument(Document document)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            Document documentInDb = _context.Documents.SingleOrDefault(p => p.Id == document.Id);

            if (documentInDb == null)
            {
                return NotFound();
            }

            documentInDb.ClientId = document.ClientId;

            //predračun
            documentInDb.OfferDate = document.OfferDate;
            documentInDb.OfferValidityDays = document.OfferValidityDays;
            documentInDb.OfferDateOfOrder = document.OfferDateOfOrder;

            //račun
            documentInDb.InvoiceDate = document.InvoiceDate;
            documentInDb.InvoiceServiceFrom = document.InvoiceServiceFrom;
            documentInDb.InvoiceServiceUntil = document.InvoiceServiceUntil;
            documentInDb.InvoiceDateOfMaturity = document.InvoiceDateOfMaturity;
            documentInDb.InvoiceDateOfOrder = document.InvoiceDateOfOrder;

            //dobavnica
            documentInDb.DeliveryNoteDate = document.DeliveryNoteDate;

            //cene
            documentInDb.TotalExcludingVAT = document.TotalExcludingVAT;
            documentInDb.DiscountPercent = document.DiscountPercent;
            documentInDb.DiscountAmount = document.DiscountAmount;
            documentInDb.AmountExcludingVAT = document.AmountExcludingVAT;
            documentInDb.AmountIncludingVAT = document.AmountIncludingVAT;

            //_context.Documents.Add(documentInDb);
            _context.SaveChanges();
            return Ok(document.Id);
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
