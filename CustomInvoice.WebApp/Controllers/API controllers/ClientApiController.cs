using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using CustomInvoice.WebApp.Data;
using CustomInvoice.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomInvoice.WebApp.Controllers.API_controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientApiController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ClientApiController(ApplicationDbContext db)
        {
            _context = db;
        }


        [HttpGet()]
        public ActionResult<Client> GetClients()
        {
            List<Client> allClients = _context.Clients.ToList();
            if (allClients.Count() == 0) { return NoContent(); }

            return Ok(allClients);
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetClient(int id)
        {
            Client selectedClient = _context.Clients.SingleOrDefault(p => p.Id == id);
            if (selectedClient == null) //not found
            {
                return NotFound();
            }

            return Ok(selectedClient);
        }

        [HttpPost()]
        public ActionResult CreateClient(Client Client)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            Client newClient = new Client();
            newClient.Name = Client.Name;
            newClient.Email = Client.Email;
            newClient.PhoneNumber = Client.PhoneNumber;
            newClient.StreetName = Client.StreetName;
            newClient.StreetNumber = Client.StreetNumber;
            newClient.PostNumber = Client.PostNumber;
            newClient.City = Client.City;
            newClient.Country = Client.Country;

            _context.Clients.Add(newClient);
            _context.SaveChanges();

            Client.Id = newClient.Id;

            return Created("api/Client/" + newClient.Id, Client);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateClient(int id, Client Client)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            Client ClientInDb = _context.Clients.SingleOrDefault(p => p.Id == id);

            if (ClientInDb == null) { return NotFound(); }

            ClientInDb.Name = Client.Name;
            ClientInDb.Email = Client.Email;
            ClientInDb.PhoneNumber = Client.PhoneNumber;
            ClientInDb.StreetName = Client.StreetName;
            ClientInDb.StreetNumber = Client.StreetNumber;
            ClientInDb.PostNumber = Client.PostNumber;
            ClientInDb.City = Client.City;
            ClientInDb.Country = Client.Country;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            Client ClientInDb = _context.Clients.SingleOrDefault(p => p.Id == id);

            if (ClientInDb == null) { return NotFound(); }

            _context.Clients.Remove(ClientInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
