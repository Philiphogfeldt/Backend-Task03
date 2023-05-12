using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Backend_Task03.Data;
using Backend_Task03.Models;

namespace Backend_Task03.Pages.Accounts
{
	public class DetailsModel : PageModel
	{
		private readonly AppDbContext database;

		public DetailsModel(AppDbContext context)
		{
			database = context;
		}

		public Account Account { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || database.Accounts == null)
			{
				return NotFound();
			}

			var account = await database.Accounts.FirstOrDefaultAsync(m => m.ID == id);

			if (account == null)
			{
				return NotFound();
			}

			else
			{
				Account = account;
			}

			return Page();
		}
	}
}
