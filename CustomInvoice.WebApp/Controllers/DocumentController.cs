using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using CustomInvoice.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomInvoice.WebApp.Controllers
{
    public class DocumentController : Controller
    {
        #region context definition
        private ApplicationDbContext _context;

        public DocumentController(ApplicationDbContext db)
        {
            _context = db;
        }

        public List<Document> GetDocuments()
        {
            var documents = new List<Document>();
            foreach (var document in _context.Documents.Include(c => c.Client))
            {
                documents.Add(document);
            }
            return documents;
        }

        public List<Article> GetArticles()
        {
            var articles = new List<Article>();
            foreach (var article in _context.Articles.Include(c => c.Product))
            {
                articles.Add(article);
            }
            return articles;
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var document = GetDocuments().SingleOrDefault(d => d.Id == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();

            if (document == null)
            {
                return NotFound();
            }

            var viewModel = new DocumentDetailsModel() { Document = document, ArticlesList = articles};

            return View("Details", viewModel);
        }

        public ActionResult New()
        {
            var articles = GetArticles();
            var clients = _context.Clients.ToList();

            var newDocument = new DocumentDetailsModel()
            {
                ClientsList = clients,
                ArticlesList = articles
            };

            return View("Edit", newDocument);
        }

        public ActionResult Edit(int id)
        {
            var document = _context.Documents.SingleOrDefault(p => p.Id == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();
            var clients = _context.Clients.ToList();

            if (document == null)
            {
                return NotFound();
            }

            var viewModel = new DocumentDetailsModel()
            {
                Document = document,
                ClientsList = clients,
                ArticlesList = articles
            };

            return View("Edit", viewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Save(DocumentDetailsModel documentForm)
        //{

        //}
    }
}
