 using SupermarketWEB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.Win32;
using SupermarketWEB.Data;

namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

		

		



		public void OnGet()
		{
			
		}

		public async Task<IActionResult> OnPostAsync() { 
        if(!ModelState.IsValid) return Page();


            if (User.Email == User.Email && User.Password == User.Password)
            {


                var claims = new List<Claim>
                 {

                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Email,User.Email),

                };


                var identify = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identify);


                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");

            }
            else { 
            
            
            }
            
            return Page();
        
        }
    }
}
