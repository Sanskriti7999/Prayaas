using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prayaas_Website.Models;


namespace Prayaas_Website.Controllers
{
    public class HomeController : Controller
    {
       

        private readonly PrayaasDbContext _context;

        public HomeController(PrayaasDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
          
            ViewData["UserTypeID"] = new SelectList(_context.UserTypes, "UserTypeID", "UserType");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Password,EmailAddress,UserTypeID")] UserModel user)
        {
            //user.AccountStatusID = 1;

            if (ModelState.IsValid)
            {           
                User usr =await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == user.EmailAddress && u.Password == user.Password && u.UserTypeID == user.UserTypeID);
                if (usr != null)
                {

                    if (usr.UserTypeID == 2 && usr.AccountStatusID == 2)
                    {
                        return RedirectToAction("DonorList", "Accounts");
                    }
                    else if (usr.UserTypeID == 1 && usr.AccountStatusID == 2)
                    {
                        return RedirectToAction("SeekerList", "Accounts");
                    }
                    else if (usr.UserTypeID == 3)
                    {
                        return RedirectToAction("AllNewUserRequests", "Accounts");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Your account under review");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username and Password is Incorrect!");
                }
               
            }

          
            ViewData["UserTypeID"] = new SelectList(_context.UserTypes, "UserTypeID", "UserType", user.UserTypeID);
            return View(user);
        }
        public IActionResult Registration()
        {

        
            ViewData["UserTypeID"] = new SelectList(_context.UserTypes, "UserTypeID", "UserType");
            return View();
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration([Bind("UserID,UserName,Password,EmailAddress,AccountStatusID,UserTypeID")] User user)
        {
            user.AccountStatusID = 1;

            if (ModelState.IsValid)
            {
                if(user.UserTypeID==3)
                {
                    return RedirectToAction(nameof(Index));
                }
                _context.Add(user);
                await _context.SaveChangesAsync();
                if(user.UserTypeID==2)
                {
                    return RedirectToAction("SeekerUser", "SelectUser");

                }
                else if(user.UserTypeID == 1)
                {
                    return RedirectToAction("DonorUser", "SelectUser");
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountStatusID"] = new SelectList(_context.AccountStatus, "accountStatusID", "accountStatus", user.AccountStatusID);
            ViewData["UserTypeID"] = new SelectList(_context.UserTypes, "UserTypeID", "UserType", user.UserTypeID);
            return View(user);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
