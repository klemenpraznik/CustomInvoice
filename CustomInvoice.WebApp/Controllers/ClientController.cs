using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using CustomInvoice.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomInvoice.WebApp.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private ApplicationDbContext _context;

        public ClientController(ApplicationDbContext db)
        {
            _context = db;
        }

        public List<Client> GetClients()
        {
            var Clients = new List<Client>();
            foreach (var Client in _context.Clients)
            {
                Clients.Add(Client);
            }
            return Clients;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            return View("Index", GetClients());
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            Client selectedClient = GetClients().SingleOrDefault(p => p.Id == id);
            if (selectedClient == null)
            {
                return NotFound();
            }

            return View(selectedClient);
        }

        public ActionResult Edit(int id)
        {
            ClientFormViewModel viewModel = new ClientFormViewModel();
            viewModel.Id = id;
            viewModel.Client = GetClients().SingleOrDefault(p => p.Id == id);
            if (viewModel.Client == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public ActionResult New()
        {
            return View("Edit", new ClientFormViewModel());
        }

        public ActionResult Delete(int id)
        {
            Client selectedClient = GetClients().SingleOrDefault(p => p.Id == id);
            if (selectedClient == null)
            {
                return NotFound();
            }
            _context.Clients.Remove(selectedClient);
            _context.SaveChanges();
            return RedirectToAction("Index", "Client");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClientFormViewModel ClientForm)
        {
            if (ClientForm.Id == 0)
            {
                if (String.IsNullOrEmpty(ClientForm.Client.RegistrationNumber) || String.IsNullOrWhiteSpace(ClientForm.Client.RegistrationNumber))
                {
                    ClientForm.Client.RegistrationNumber = "";
                }
                _context.Clients.Add(ClientForm.Client);
            }
            else
            {
                var ClientInDb = _context.Clients.Single(p => p.Id == ClientForm.Id);

                ClientInDb.Name = ClientForm.Client.Name;

                ClientInDb.Type = ClientForm.Client.Type;
                ClientInDb.RegistrationNumber = ClientForm.Client.RegistrationNumber;
                ClientInDb.taxNumber = ClientForm.Client.taxNumber;
                ClientInDb.taxPayer = ClientForm.Client.taxPayer;


                ClientInDb.Email = ClientForm.Client.Email;
                ClientInDb.PhoneNumber = ClientForm.Client.PhoneNumber;

                ClientInDb.StreetName = ClientForm.Client.StreetName;
                ClientInDb.StreetNumber = ClientForm.Client.StreetNumber;
                ClientInDb.PostNumber = ClientForm.Client.PostNumber;
                ClientInDb.City = ClientForm.Client.City;
                ClientInDb.Country = ClientForm.Client.Country;
                if (String.IsNullOrEmpty(ClientInDb.RegistrationNumber) || String.IsNullOrWhiteSpace(ClientInDb.RegistrationNumber))
                {
                    ClientInDb.RegistrationNumber = "";
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Client");
        }

    }
}
