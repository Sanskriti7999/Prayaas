using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prayaas_Website.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Prayaas_Website.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly PrayaasDbContext _context;

        public DonorsController(PrayaasDbContext context)
        {
            _context = context;
        }

        //GET/api/donors
        public IEnumerable<Donor> GetDonors()
        {
            return _context.Donors.ToList();
        }
        //GET/api/donors/1
        [HttpGet("{id}")]
        public Donor GetDonor(int id)
        {
            var donor = _context.Donors.FirstOrDefault(d => d.DonorID == id);
            if (donor == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return donor;
        }
        //POST /api/donors 
        [HttpPost]
        public Donor PostDonor(Donor donor)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Donors.Add(donor);
            _context.SaveChanges();

            return donor;

        }
        //POST /api/donors/1
        [HttpPut]
        public void UpdateDonor(int id , Donor donor)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var donorInDb = _context.Donors.FirstOrDefault(d => d.DonorID == id);

            if (donorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            donorInDb.FullName=donor.FullName;
            donorInDb.Adhaar = donor.Adhaar;
            donorInDb.ContactNo = donor.ContactNo;
            donorInDb.LastDonationDate = donor.LastDonationDate;

            _context.SaveChanges();
        }
        [HttpDelete]    
        public void DeleteDonor(int id)
        {
            var donorInDb = _context.Donors.FirstOrDefault(d => d.DonorID == id);

            if(donorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Donors.Remove(donorInDb);
            _context.SaveChanges();

        }

    }
}
