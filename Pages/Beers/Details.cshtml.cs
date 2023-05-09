using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Backend_Task03.Data;
using Backend_Task03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;

namespace Backend_Task03.Pages.Beers
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext database;

        private readonly AccessControl accessControl; // testar mig fram här


        public DetailsModel(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            database = context;

            accessControl = new AccessControl(database, httpContextAccessor);
        }

        [BindProperty]
        public Beer Beer { get; set; } = default!;

        [BindProperty]
        public Review NewReview { get; set; }

        [BindProperty]
        public Account Account { get; set; }

        public void LoadBeer(int id)
        {
            Beer = database.Beers

                .Include(b => b.Reviews).ThenInclude(b=> b.Account)
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
                Beer = Beer,
            };
        }

        public void ActiveAccount()
        {
            Account = accessControl.LoggedInAccount;
        }

        public IActionResult OnGet(int id)
        {
            LoadBeer(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            LoadBeer(id);

            // behövs inte account här? 

            ActiveAccount();
            //NewReview.Account = accessControl.LoggedInAccount; // Set the AccountID of the new review
            NewReview.Account = Account;


            //bool success = 
                await TryUpdateModelAsync(
                NewReview,
                nameof(NewReview),
                c => c.Rating,
                c => c.Comment,
                c => c.Beer
                );

                        
/*            if (success)
            {
                Beer.Reviews.Add(NewReview);
                database.Reviews.Add(NewReview);
                database.SaveChanges();
                return RedirectToPage();
            }
            else
            {
                return Page();
            }*/

            Beer.Reviews.Add(NewReview);
            database.Reviews.Add(NewReview);
            database.SaveChanges();
            return RedirectToPage("./Details", new {id = Beer.ID });
        }
    }
}