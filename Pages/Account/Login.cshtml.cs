 using SupermarketWEB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.Win32;
using SupermarketWEB.Data;
using Microsoft.EntityFrameworkCore;

namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SupermarketContext _context;

        [BindProperty]
        public User User { get; set; }

        public LoginModel(SupermarketContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var registro = await _context.Registers.FirstOrDefaultAsync(r => r.Email == User.Email && r.Password == User.Password);

            if (registro != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Email, registro.Email),
            };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
            return Page();
        }
    }
}

