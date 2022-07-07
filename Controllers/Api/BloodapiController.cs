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
    public class BloodapiController : ControllerBase
    {
        private readonly PrayaasDbContext _context;

        public BloodapiController(PrayaasDbContext context)
        {
            _context = context;
        }

        //GET/api/donors
        public IEnumerable<BloodGroups> GetBloodGroupss()
        {
            return _context.BloodGroups.ToList();
        }
        //GET/api/donors/1
        [HttpGet("{id}")]
        public BloodGroups GetBloodGroup(int id)
        {
            var bloodgroup = _context.BloodGroups.FirstOrDefault(d => d.BloodGroupID == id);
            if (bloodgroup == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return bloodgroup;
        }
        //POST /api/donors 
        [HttpPost]
        public BloodGroups PostBloodGroup(BloodGroups bloodgroup)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.BloodGroups.Add(bloodgroup);
            _context.SaveChanges();

            return bloodgroup;

        }
        //POST /api/donors/1
        [HttpPut]
        public void UpdateBloodGroup(int id, BloodGroups bloodgroup)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bloodgroupInDb = _context.BloodGroups.FirstOrDefault(d => d.BloodGroupID == id);

            if (bloodgroupInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            bloodgroup.BloodGroupID = bloodgroup.BloodGroupID;
            bloodgroup.BloodGroup = bloodgroup.BloodGroup;

            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteBloodGroup(int id)
        {
            var bloodgroupInDb = _context.BloodGroups.FirstOrDefault(d => d.BloodGroupID == id);

            if (bloodgroupInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.BloodGroups.Remove(bloodgroupInDb);
            _context.SaveChanges();

        }

    }
}
