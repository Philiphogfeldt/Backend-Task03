using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend_Task03.Data;
using Backend_Task03.Models;

namespace Backend_Task03.Pages.Accounts
{
	public class EditModel : PageModel
	{
		private readonly AppDbContext database;

		public EditModel(AppDbContext context)
		{
			database = context;
		}

		[BindProperty]
		public Account Account { get; set; } = default!;

		private void LoadAccount(int id)
		{
			Account = database.Accounts.Include(a => a.Reviews).FirstOrDefault(a => a.ID == id);
		}

		public async Task<IActionResult> OnGetAsync(int id)
		{
			//if (id == null || database.Accounts == null)
			//{
			//    return NotFound();
			//}

			//var account =  await database.Accounts.FirstOrDefaultAsync(m => m.ID == id);

			//if (account == null)
			//{
			//    return NotFound();
			//}

			//Account = account;
			LoadAccount(id);
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync(int id)
		{
			LoadAccount(id);
			bool success = await TryUpdateModelAsync(
				Account, nameof(Account),
				a => a.OpenIDIssuer,
				a => a.OpenIDSubject,
				a => a.Name,
				a => a.Role);
			if (success)
			{
				database.SaveChanges();
				return RedirectToPage("./Details");
			}

			else
			{
				return Page();
			}
			//if (!ModelState.IsValid)
			//{
			//    return Page();
			//}

			//database.Attach(Account).State = EntityState.Modified;

			//try
			//{
			//    await database.SaveChangesAsync();
			//}

			//catch (DbUpdateConcurrencyException)
			//{
			//    if (!AccountExists(Account.ID))
			//    {
			//        return NotFound();
			//    }

			//    else
			//    {
			//        throw;
			//    }
			//}

			return RedirectToPage("./Index");
		}

		private bool AccountExists(int id)
		{
			return (database.Accounts?.Any(e => e.ID == id)).GetValueOrDefault();
		}
	}
}
