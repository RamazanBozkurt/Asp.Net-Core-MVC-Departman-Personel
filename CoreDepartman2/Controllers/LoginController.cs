using CoreDepartman2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDepartman2.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GirisYap(Admin a)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == a.Kullanici && x.Sifre == a.Sifre);
            
            if(bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name, a.Kullanici)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Personel");   // işlem bittikten sonra persone controller daki index e git
            }
            return View();
        }
    }
}
