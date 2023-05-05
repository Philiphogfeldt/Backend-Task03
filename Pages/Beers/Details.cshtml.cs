using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Backend_Task03.Data;
using Backend_Task03.Models;

namespace Backend_Task03.Pages.Beers
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext database;

        public DetailsModel(AppDbContext context)
        {
            database = context;
        }

        [BindProperty]
        public Beer Beer { get; set; } = default!;

        [BindProperty]
        public Review NewReview { get; set; }

        public void LoadBeer(int id)
        {
            Beer = database.Beers
                .Include(b => b.Reviews)
                .FirstOrDefault(b => b.ID == id);

            if (Beer == null)
            {
                return;
            }

            if (Beer.Reviews == null)
            {
                Beer.Reviews = new List<Review>();
            }

            NewReview = new Review
            {
                Beer = Beer
            };
        }

        public IActionResult OnGet(int id)
        {
            LoadBeer(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            LoadBeer(id);

            bool success = await TryUpdateModelAsync(
                NewReview,
                nameof(NewReview),
                c => c.Comment,
                c => c.Beer);


            if (success)
            {
                Beer.Reviews.Add(NewReview);
                database.SaveChanges();
                return RedirectToPage();
            }
            else
            {
                return Page();
            }
        }
    }
}