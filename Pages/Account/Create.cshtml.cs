using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Account
{
    public class CreateModel : PageModel
    {
		private readonly SupermarketContext _context;

		public CreateModel(SupermarketContext context)
		{

			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]

		public Register Register { get; set; } = default!;
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Registers == null || Register == null)
			{

				return Page();
			}
			_context.Registers.Add(Register);
			await _context.SaveChangesAsync();
			return RedirectToPage("/Account/Login");

		}
	}
}
