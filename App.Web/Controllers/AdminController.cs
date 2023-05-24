using App.Core.DTOs;
using App.Core.Models;
using App.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace App.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminDto p)
        {
			if (ModelState.IsValid)
			{
				// Giriş bilgilerini kontrol et
				var admin = _context.Admins.FirstOrDefault(a => a.userName == p.userName && a.userPassword == p.userPassword);
				if (admin != null)
				{
					if (admin.Role == "Admin")
					{
						// Kullanıcının rolü "Admin" ise oturum aç ve yönlendir
						var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, admin.userName),
					new Claim(ClaimTypes.Role, admin.Role)
				};

						var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
						var authProperties = new AuthenticationProperties
						{
							// İsteğin yönlendirileceği sayfa
							RedirectUri = "/Home/Index"
						};

						await HttpContext.SignInAsync(
							CookieAuthenticationDefaults.AuthenticationScheme,
							new ClaimsPrincipal(claimsIdentity),
							authProperties);

						return RedirectToAction("Index", "Home");
					}
					else
					{
						ModelState.AddModelError("", "Yetkisiz erişim girişimi.");
					}
				}
				else
				{
					ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre girişi yaptınız.");
				}
			}

			// Hatalı giriş durumunda login sayfasını tekrar göster
			return View(p);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Login", "Admin");
		}
	}
}

