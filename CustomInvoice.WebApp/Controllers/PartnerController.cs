using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomInvoice.WebApp.Controllers
{
    public class PartnerController : Controller
    {
        private ApplicationDbContext _context;

        public PartnerController(ApplicationDbContext db)
        {
            _context = db;
        }

        public List<Partner> GetPartners()
        {
            var partners = new List<Partner>();
            foreach (var partner in _context.Partners)
            {
                partners.Add(partner);
            }
            return partners;
        }

        // GET: PartnerController
        public ActionResult Index()
        {
            return View("Index", GetPartners());
        }

        // GET: PartnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PartnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PartnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
