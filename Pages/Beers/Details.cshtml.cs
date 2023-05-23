﻿using System;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        [BindProperty]
        public List<FoodCategory> ThisReviewFoodcategories { get; set; }


        [BindProperty]
        public bool Meat { get; set; }

        [BindProperty]
        public bool Chicken { get; set; }

        [BindProperty]
        public bool Fish { get; set; }
        [BindProperty]
        public bool Vegetarian { get; set; }
        [BindProperty]
        public bool Dessert { get; set; }


        public void LoadBeer(int id)
        {
            Beer = database.Beers
                .Include(b => b.Reviews).ThenInclude(b => b.Account)
                .FirstOrDefault(b => b.ID == id);

            //oklart om den ska ligga redan här
            //FoodCategoriesFromDb = database.FoodCategories.ToList();  

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
                //oklart om denna ska ligga här
                FoodCategories = ThisReviewFoodcategories
            };

        }


        public void ActiveAccount()
        {
            Account = accessControl.LoggedInAccount;
        }

        public IActionResult OnGet(int id)
        {
            Beer = database.Beers
               .Include(b => b.Reviews).ThenInclude(r => r.FoodCategories)
               .FirstOrDefault(b => b.ID == id);

            if (Beer.Reviews.Any())
            {
                decimal ratingValueCount = 0;
                decimal reviewCount = Beer.Reviews.Count;

                Dictionary<string, int> categoryCounts = new Dictionary<string, int>();

                // Count the number of times each category appears in the reviews
                foreach (var review in Beer.Reviews)
                {
                    foreach (var category in review.FoodCategories)
                    {
                        if (categoryCounts.ContainsKey(category.Name))
                        {
                            categoryCounts[category.Name]++;
                        }
                        else
                        {
                            categoryCounts[category.Name] = 1;
                        }
                    }

                    ratingValueCount += review.Rating;
                }

                // Find the category/categories with the highest count
                List<string> mostSelectedCategories = new List<string>();
                int highestCount = 0;
                foreach (var kvp in categoryCounts)
                {
                    if (kvp.Value > highestCount)
                    {
                        mostSelectedCategories.Clear();
                        mostSelectedCategories.Add(kvp.Key);
                        highestCount = kvp.Value;
                    }
                    else if (kvp.Value == highestCount)
                    {
                        mostSelectedCategories.Add(kvp.Key);
                    }
                }

                // Update the Rating property
                decimal totalRating = Math.Round(ratingValueCount / reviewCount, 1);
                Beer.Rating = (double)totalRating;

                // Update the GoesWellWith property
                Beer.GoesWellWith = string.Join(", ", mostSelectedCategories);

                database.SaveChanges();
            }

            LoadBeer(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            LoadBeer(id);

            ActiveAccount();
            //NewReview.Account = accessControl.LoggedInAccount; // Set the AccountID of the new review
            NewReview.Account = Account;


            if (Chicken == true)
            {
                var chicken = database.FoodCategories.FirstOrDefault(c => c.Name == "Chicken");
                ThisReviewFoodcategories.Add(chicken);

            }
            if (Meat == true)
            {
                var meat = database.FoodCategories.FirstOrDefault(c => c.Name == "Meat");
                ThisReviewFoodcategories.Add(meat);

            }
            if (Fish == true)
            {
                var fish = database.FoodCategories.FirstOrDefault(c => c.Name == "Fish");
                ThisReviewFoodcategories.Add(fish);

            }
            if (Vegetarian == true)
            {
                var veg = database.FoodCategories.FirstOrDefault(c => c.Name == "Vegetarian");
                ThisReviewFoodcategories.Add(veg);

            }
            if (Dessert == true)
            {
                var dessert = database.FoodCategories.FirstOrDefault(c => c.Name == "Dessert");
                ThisReviewFoodcategories.Add(dessert);

            }


            //bool success = 
            await TryUpdateModelAsync(
                NewReview,
                nameof(NewReview),
                c => c.Rating,
                c => c.Comment,
                c => c.Beer
                );



            /*            
            if (success)
            {
                Beer.Reviews.Add(NewReview);
                database.Reviews.Add(NewReview);
                database.SaveChanges();
                return RedirectToPage();
            }
            else
            {
                return Page();

            } */


            //förstår inte riktigt varför båda dessa behövs
            //Account.Reviews.Add(NewReview);
            Beer.Reviews.Add(NewReview);
            database.Reviews.Add(NewReview);
            database.SaveChanges();
            return RedirectToPage("./Details", new { id = Beer.ID, name = Beer.Name });
        }
    }
}