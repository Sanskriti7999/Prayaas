using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prayaas_Website.Models;
using System;
using System.Linq;

namespace Prayaas_Website.Controllers
{
    public class AccountsController : Controller
    {
        private readonly PrayaasDbContext _context;

        public AccountsController(PrayaasDbContext context)
        {
            _context = context;
        }
        public IActionResult AllNewUserRequests()
        {
            /*  if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Session.GetString("UserName"))))
              {
                  return RedirectToAction("Login", "Home");
              } */
            var users = _context.Users.Where(u => u.AccountStatusID == 1).ToList();
            return View(users);
        }
      /*  public IActionResult UserDetail(int? id)
        {
            /*  if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Session.GetString("UserName"))))
              {
                  return RedirectToAction("Login", "Home");
              } 
            var user = _context.Users.Find(id);
            return View();

        }*/
        public IActionResult UserApproved(int? id)
        {
            /* if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Session.GetString("UserName"))))
         {
             return RedirectToAction("Login", "Home");
         }*/
            var user = _context.Users.Find(id);
            user.AccountStatusID = 2;
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("AllNewUserRequests");
        }

        public IActionResult UserDenied(int? id)
        {
           /* if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Session.GetString("UserName"))))
            {
                return RedirectToAction("Login", "Home");
            }*/
            var user = _context.Users.Find(id);
            user.AccountStatusID = 3;
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("AllNewUserRequests");
        }

        public IActionResult SeekerList()
        {
            return View(_context.Seekers);
        }

        public IActionResult DonorList()
        {
            return View(_context.Donors);
        }

        public IActionResult InstitutionList()
        {
            return View();
        }
    }
}
