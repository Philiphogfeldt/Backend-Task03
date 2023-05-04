using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Backend_Task03.Data;
using Backend_Task03.Models;
using Backend_Task03.Utilities;

namespace Backend_Task03.Pages.Beers
{
    public class CreateModel : PageModel
    {
        private readonly Backend_Task03.Data.AppDbContext _context;

        public CreateModel(Backend_Task03.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Beer Beer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Beers == null || Beer == null)
            {
                return Page();
            }

            _context.Beers.Add(Beer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
