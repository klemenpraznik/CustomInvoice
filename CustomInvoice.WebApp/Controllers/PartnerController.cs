using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using CustomInvoice.WebApp.ViewModels;
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
            Partner selectedPartner = GetPartners().SingleOrDefault(p => p.Id == id);
            if (selectedPartner == null)
            {
                return NotFound();
            }

            return View(selectedPartner);
        }

        public ActionResult Edit(int id)
        {
            PartnerFormViewModel viewModel = new PartnerFormViewModel();
            viewModel.Id = id;
            viewModel.Partner = GetPartners().SingleOrDefault(p => p.Id == id);
            if (viewModel.Partner == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public ActionResult New()
        {
            return View("Edit", new PartnerFormViewModel());
        }

        public ActionResult Delete(int id)
        {
            Partner selectedPartner = GetPartners().SingleOrDefault(p => p.Id == id);
            if (selectedPartner == null)
            {
                return NotFound();
            }
            _context.Partners.Remove(selectedPartner);
            _context.SaveChanges();
            return RedirectToAction("Index", "Partner");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PartnerFormViewModel partnerForm)
        {
            if (partnerForm.Id == 0)
            {
                _context.Partners.Add(partnerForm.Partner);
            }
            else
            {
                var partnerInDb = _context.Partners.Single(p => p.Id == partnerForm.Id);

                partnerInDb.Name = partnerForm.Partner.Name;
                partnerInDb.Email = partnerForm.Partner.Email;
                partnerInDb.PhoneNumber = partnerForm.Partner.PhoneNumber;
                partnerInDb.StreetName = partnerForm.Partner.StreetName;
                partnerInDb.StreetNumber = partnerForm.Partner.StreetNumber;
                partnerInDb.PostNumber = partnerForm.Partner.PostNumber;
                partnerInDb.City = partnerForm.Partner.City;
                partnerInDb.Country = partnerForm.Partner.Country;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Partner");
        }

    }
}
