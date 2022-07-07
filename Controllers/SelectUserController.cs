using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prayaas_Website.Models;
using System.Threading.Tasks;

namespace Prayaas_Website.Controllers
{
    public class SelectUserController : Controller

    {
        private readonly PrayaasDbContext _context;

        public SelectUserController(PrayaasDbContext context)
        {
            _context = context;
        }
        public IActionResult SeekerUser()
        {
            ViewData["BloodGroupID"] = new SelectList(_context.BloodGroups, "BloodGroupID", "BloodGroup");
            ViewData["CityID"] = new SelectList(_context.Citys, "CityID", "City");
            ViewData["GenderID"] = new SelectList(_context.Genders, "GenderID", "Gender");
            
            return View();
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SeekerUser([Bind("FullName, Age, ContactNo, Adhaar, RegistrationDate, BloodGroupID, CityID, GenderID, UserID ")] Seeker seeker)
        {

            seeker.UserID = 1;

            if (ModelState.IsValid)
            {
                _context.Add(seeker);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserName", seeker.UserID);
            ViewData["BloodGroupID"] = new SelectList(_context.BloodGroups, "BloodGroupID", "BloodGroup", seeker.BloodGroupID);
            ViewData["CityID"] = new SelectList(_context.Citys, "CityID", "City", seeker.CityID);
            ViewData["GenderID"] = new SelectList(_context.Genders, "GenderID", "Gender", seeker.GenderID);
            return View(seeker);
        }
        public IActionResult DonorUser()
        {
            ViewData["BloodGroupID"] = new SelectList(_context.BloodGroups, "BloodGroupID", "BloodGroup");
            ViewData["CityID"] = new SelectList(_context.Citys, "CityID", "City");
            ViewData["GenderID"] = new SelectList(_context.Genders, "GenderID", "Gender");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DonorUser([Bind("FullName, BloodGroupID, LastDonationDate, Adhaar, RegistrationDate,Location,ContactNo, CityID, UserID, GenderID ")] Donor donor)
        {

            donor.UserID = 1;

            if (ModelState.IsValid)
            {
                _context.Add(donor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserName", donor.UserID);
            ViewData["BloodGroupID"] = new SelectList(_context.BloodGroups, "BloodGroupID", "BloodGroup", donor.BloodGroupID);
            ViewData["CityID"] = new SelectList(_context.Citys, "CityID", "City", donor.CityID);
            ViewData["GenderID"] = new SelectList(_context.Genders, "GenderID", "Gender", donor.GenderID);
            return View(donor);
        }

    }
}
