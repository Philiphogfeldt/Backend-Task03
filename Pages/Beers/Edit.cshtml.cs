﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend_Task03.Data;
using Backend_Task03.Models;

namespace Backend_Task03.Pages.Beers
{
    public class EditModel : PageModel
    {
        private readonly Backend_Task03.Data.AppDbContext _context;

        public EditModel(Backend_Task03.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beer Beer { get; set; } = default!;

        public List<string> CountryOptions { get; } = new List<string>
        {
        "Australia",
        "Belgium",
        "Canada",
        "Denmark",
        "Ecuador",
        "France",
        "Germany",
        "Honduras",
        "Ireland",
        "Jamaica",
        "Kenya",
        "Lebanon",
        "Mexico",
        "Netherlands",
        "Oman",
        "Portugal",
        "Russia",
        "Spain",
        "Turkey",
        "United States",
        "Vietnam",
        "Yemen",
        "Zimbabwe"
        };


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Beers == null)
            {
                return NotFound();
            }

            var beer =  await _context.Beers.FirstOrDefaultAsync(m => m.ID == id);
            if (beer == null)
            {
                return NotFound();
            }
            Beer = beer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Beer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeerExists(Beer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BeerExists(int id)
        {
          return (_context.Beers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
