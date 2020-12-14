using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using CustomInvoice.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

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

        public ActionResult ExportOffer(int id) //predracun PDF
        {
            var document = GetDocuments().SingleOrDefault(d => d.Id == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();

            if (document == null)
            {
                return NotFound();
            }

            var viewModel = new DocumentDetailsModel() { Document = document, ArticlesList = articles };

            return new ViewAsPdf(viewModel)
            {
                FileName = "predracun_" + id + "-" + document.Client.Name.Replace(" ", "_"),
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0),
                CustomSwitches = "--disable-smart-shrinking"
            };
            //return View("ExportOffer", viewModel);
        }

        public ActionResult ExportInvoice(int id) //račun PDF
        {
            var document = GetDocuments().SingleOrDefault(d => d.Id == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();

            if (document == null)
            {
                return NotFound();
            }

            var viewModel = new DocumentDetailsModel() { Document = document, ArticlesList = articles };

            return new ViewAsPdf(viewModel)
            {
                FileName = "racun_" + id + "-" + document.Client.Name.Replace(" ", "_"),
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0),
                CustomSwitches = "--disable-smart-shrinking"
            };
            //return View("ExportOffer", viewModel);
        }

        public ActionResult ExportDeliveryNote(int id) //račun PDF
        {
            var document = GetDocuments().SingleOrDefault(d => d.Id == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();

            if (document == null)
            {
                return NotFound();
            }

            var viewModel = new DocumentDetailsModel() { Document = document, ArticlesList = articles };

            return new ViewAsPdf(viewModel)
            {
                FileName = "dobavnica" + id + "-" + document.Client.Name.Replace(" ", "_"),
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 0, 0, 0),
                CustomSwitches = "--disable-smart-shrinking"
            };
            //return View("ExportDeliveryNote", viewModel);
        }

        public ActionResult New()
        {
            var newDocument = new DocumentEditModel()
            {
                Document = null,
                ClientsList = _context.Clients.ToList(),
                ArticlesList = null,
                ProductList = _context.Products.ToList()
            };

            return View("New", newDocument);
        }

        public ActionResult Edit(int id)
        {
            var document = _context.Documents.SingleOrDefault(p => p.Id == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();
            var clients = _context.Clients.ToList();
            var products = _context.Products.ToList();

            if (document == null)
            {
                return NotFound();
            }

            var viewModel = new DocumentEditModel()
            {
                Document = document,
                ClientsList = clients,
                ArticlesList = articles,
                ProductList = products
            };

            return View("Edit", viewModel);
        }
    }
}
