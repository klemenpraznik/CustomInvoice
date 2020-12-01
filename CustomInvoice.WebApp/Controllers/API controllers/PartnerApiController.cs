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
    [Route("api/partner")]
    [ApiController]
    public class PartnerApiController : ControllerBase
    {
        private ApplicationDbContext _context;

        public PartnerApiController(ApplicationDbContext db)
        {
            _context = db;
        }


        [HttpGet()]
        public ActionResult<Partner> GetPartners()
        {
            List<Partner> allPartners = _context.Partners.ToList();
            if (allPartners.Count() == 0) { return NoContent(); }

            return Ok(allPartners);
        }

        [HttpGet("{id}")]
        public ActionResult<Partner> GetPartner(int id)
        {
            Partner selectedPartner = _context.Partners.SingleOrDefault(p => p.Id == id);
            if (selectedPartner == null) //not found
            {
                return NotFound();
            }

            return Ok(selectedPartner);
        }

        [HttpPost()]
        public ActionResult CreatePartner(Partner partner)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            Partner newPartner = new Partner();
            newPartner.Name = partner.Name;
            newPartner.Email = partner.Email;
            newPartner.PhoneNumber = partner.PhoneNumber;
            newPartner.StreetName = partner.StreetName;
            newPartner.StreetNumber = partner.StreetNumber;
            newPartner.PostNumber = partner.PostNumber;
            newPartner.City = partner.City;
            newPartner.Country = partner.Country;

            _context.Partners.Add(newPartner);
            _context.SaveChanges();

            partner.Id = newPartner.Id;

            return Created("api/partner/" + newPartner.Id, partner);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePartner(int id, Partner partner)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            Partner partnerInDb = _context.Partners.SingleOrDefault(p => p.Id == id);
            
            if (partnerInDb == null) { return NotFound(); }

            partnerInDb.Name = partner.Name;
            partnerInDb.Email = partner.Email;
            partnerInDb.PhoneNumber = partner.PhoneNumber;
            partnerInDb.StreetName = partner.StreetName;
            partnerInDb.StreetNumber = partner.StreetNumber;
            partnerInDb.PostNumber = partner.PostNumber;
            partnerInDb.City = partner.City;
            partnerInDb.Country = partner.Country;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePartner(int id)
        {
            Partner partnerInDb = _context.Partners.SingleOrDefault(p => p.Id == id);

            if (partnerInDb == null) { return NotFound(); }

            _context.Partners.Remove(partnerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
