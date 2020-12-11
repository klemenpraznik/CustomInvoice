using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Dtos;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomInvoice.WebApp.Controllers.API_controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesApiController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ArticlesApiController(ApplicationDbContext db)
        {
            _context = db;
        }

        [HttpGet("{documentId}")]
        public ActionResult<Article> GetArticles(int documentId) //get all articles from one document (by documentId)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            Document document = _context.Documents.SingleOrDefault(p => p.Id == documentId);

            if (document == null) //this document does not exist
            {
                return NotFound();
            }

            //if document exists, find all articles with its ID
            List<Article> articles = _context.Articles.Include(p => p.Product).Where(p => p.DocumentId == documentId).ToList();

            return Ok(articles);
        }

        [HttpPost("{documentId}")]
        public ActionResult CreateArticles(ArticlesDto articleDto) //delete previous articles and insert new ones
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var documentId = articleDto.DocumentId;

            Document document = _context.Documents.SingleOrDefault(p => p.Id == documentId);

            if (document == null) //this document does not exist
            {
                return NotFound();
            }

            List<Article> articlesInDb = _context.Articles.Where(p => p.DocumentId == documentId).ToList();
            foreach (var article in articlesInDb)
            {
                _context.Remove(article);
            }

            //if document exists, find all articles with its ID
            foreach (var article in articleDto.Articles)
            {
                _context.Add(article);

            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
