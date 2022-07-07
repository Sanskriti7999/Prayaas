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
    public class SeekerController : ControllerBase
    {
        private readonly PrayaasDbContext _context;

        public SeekerController(PrayaasDbContext context)
        {
            _context = context;
        }

        //GET/api/donors
        public IEnumerable<Seeker> GetSeekers()
        {
            return _context.Seekers.ToList();
        }
        //GET/api/donors/1
        [HttpGet("{id}")]
        public Seeker GetSeeker(int id)
        {
            var seeker = _context.Seekers.FirstOrDefault(d => d.SeekerID == id);
            if (seeker == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return seeker;
        }
        //POST /api/donors 
        [HttpPost]
        public Seeker PostSeeker(Seeker seeker)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Seekers.Add(seeker);
            _context.SaveChanges();

            return seeker;

        }
        //POST /api/donors/1
        [HttpPut]
        public void UpdateSeeker(int id, Seeker seeker)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var seekerInDb = _context.Seekers.FirstOrDefault(d => d.SeekerID == id);

            if (seekerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            seekerInDb.FullName = seeker.FullName;
            seekerInDb.Adhaar = seeker.Adhaar;
            seekerInDb.ContactNo = seeker.ContactNo;
            seekerInDb.Age = seeker.Age;

            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteSeeker(int id)
        {
            var seekerInDb = _context.Seekers.FirstOrDefault(d => d.SeekerID == id);

            if (seekerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Seekers.Remove(seekerInDb);
            _context.SaveChanges();

        }

    }
}

