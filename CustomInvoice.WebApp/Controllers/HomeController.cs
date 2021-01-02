using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CustomInvoice.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _context = db;
        }

        public List<Article> getBestSellingArticles(int number)
        {
            var query = _context.Articles
                 .GroupBy(c => new
                 {
                     c.ProductId
                 })
                 .Select(group => new
                 {
                     ArticleId = 0,
                     DocumentId = 0,
                     ProductId = group.Key.ProductId,
                     Quantity = group.Sum(x => x.Quantity),
                     Price = group.Sum(x => x.Price),
                     Discount = 0,
                     taxRate = 0
                 })
                 .OrderByDescending(order => order.Quantity)
                 .Take(number)
                 .ToList();

            List<Article> bestSeller = new List<Article>();
            foreach (var element in query)
            {
                Article newArticle = new Article();
                newArticle.ArticleId = element.ArticleId;
                newArticle.DocumentId = (byte)element.DocumentId;
                newArticle.ProductId = element.ProductId;
                newArticle.Product = _context.Products.SingleOrDefault(x => x.Id == element.ProductId);
                newArticle.Quantity = element.Quantity;
                newArticle.Price = element.Price;
                newArticle.TaxRate = element.taxRate;
                bestSeller.Add(newArticle);
            }

            return bestSeller;
        }

        public List<ClientTypeCount> GetClientTypeRepresentation()
        {
            var query = _context.Clients
                .GroupBy(c => new
                {
                    c.Type
                })
                .OrderBy(x => x.Key.Type)
                .Select(a => new
                {
                    name = a.Key.Type,
                    count = a.Count()
                })
                .ToList();

            List<ClientTypeCount> list = new List<ClientTypeCount>();
            foreach(var element in query)
            {
                ClientTypeCount temp = new ClientTypeCount()
                {
                    Name = element.name,
                    Count = element.count
                };
                list.Add(temp);
            }

            return list;
        }

        public List<ClientTypeCount> GetClientTypeRepresentationByDocuments()
        {
            var query = _context.Documents
                 .Include(a => a.Client)
                 .GroupBy(c => new
                 {
                     c.Client.Type
                 })
                 .Select(a => new
                 {
                     name = a.Key.Type,
                     count = a.Count()
                 })
                 .ToList();

            List<ClientTypeCount> list = new List<ClientTypeCount>();
            foreach(var element in query)
            {
                ClientTypeCount temp = new ClientTypeCount()
                {
                    Name = element.name,
                    Count = element.count
                };
                list.Add(temp);
            }

            return list;
        }


        public IActionResult Index()
        {
            Stats stats = new Stats();
            stats.TotalProducts = _context.Products.Count(a => a.Type == "Artikel");
            stats.TotalServices = _context.Products.Count(a => a.Type == "Storitev");
            stats.BestSellingArticles = getBestSellingArticles(5);
            stats.ClientTypeCount = GetClientTypeRepresentation();
            stats.NumberOfClients = _context.Clients.Count();
            stats.NumberOfDocuments = _context.Documents.Count();
            stats.ClientTypeCountByDocument = GetClientTypeRepresentationByDocuments();

            return View(stats);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
