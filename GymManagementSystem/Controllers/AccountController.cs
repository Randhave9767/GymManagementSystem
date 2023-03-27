using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using GymManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol;

namespace GymManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly GymDatabaseContext _context;

        public AccountController(GymDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            if (username == "admin" && password == "admin")
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme
                );
                isAuthenticated = true;
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Admin");
            }
            if (_context.Users.Any(x => x.Username == username && x.Password == password))
            {
                //User u1 =  _context.Users.FirstOrDefault(x=>x.Username == username && x.Password == password);
                User u = _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

                if (_context.Trainers.Any(t=>t.UserId == u.Id ))
                {
                    Trainer t = _context.Trainers.Include(t=>t.User).Include(t=>t.Members).FirstOrDefault(t => t.UserId == u.Id);
                    identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, username),
                       
                        new Claim(ClaimTypes.Role, "trainer")
                    },
                    CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                    var principal1 = new ClaimsPrincipal(identity);
                    var login1 = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal1);

                    this.HttpContext.Session.SetInt32("Id", t.Id);
                    return RedirectToAction("Index", "TrainerHome", new { id = t.Id });
                }

                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "user")
                }, CookieAuthenticationDefaults.AuthenticationScheme
                );
                isAuthenticated = true;
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                this.HttpContext.Session.SetInt32("Id", u.Id);
                return RedirectToAction("Index", "User", new { id = u.Id });
            }

           

            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup([Bind("Id,FullName,Username,Password,MobileNo")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            
            return View();
            

            
        }

        public ActionResult Logout2()
        
        
       {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }

}
