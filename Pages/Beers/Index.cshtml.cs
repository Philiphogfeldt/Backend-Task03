using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Task03.Data;
using Backend_Task03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Backend_Task03.Pages.Beers
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext database;

        public IndexModel(AppDbContext context)
        {
            database = context;
        }

        public IList<Beer> Beer { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FindBeer { get; set; }

        [BindProperty(SupportsGet = true)]
        public string[] BeerType { get; set; }

        public string Chicken { get; set; }
        public string Meat { get; set; }
        public string Fish { get; set; }
        public string Vegetarian { get; set; }
        public string Dessert { get; set; }

        public async Task OnGetAsync(string searchInput)
        {
            IQueryable<Beer> beers = database.Beers;

            if (!string.IsNullOrEmpty(searchInput))
            {
                beers = beers.Where(b => b.Name.Contains(searchInput) || b.EAN13 == searchInput);
            }
            if (!string.IsNullOrEmpty(FindBeer))
            {
                beers = beers.Where(b => b.Name.Contains(FindBeer));
            }

            // BeerType filtering
            if (BeerType != null && BeerType.Length > 0)
            {
                List<string> types = new List<string>();
                if (BeerType.Contains("Ale"))
                {
                    types.AddRange(new string[] { "Ale", "Brown Ale", "IPA", "Wheat Ale", "Belgian Ale", "Saison" });
                }
                if (BeerType.Contains("Lager"))
                {
                    types.AddRange(new string[] { "Lager", "Kolsch"});
                }
                if (BeerType.Contains("Stout"))
                {
                    types.AddRange(new string[] { "Stout", "Imperial Stout"});
                }
                beers = beers.Where(b => types.Contains(b.Type));
            }

            Beer = await beers.ToListAsync();

            var allBeers = await database.Beers.Include(b => b.Reviews).ThenInclude(r => r.FoodCategories).ToListAsync();

            foreach (var beer in allBeers)
            {
                if (beer.Reviews.Any())
                {
                    decimal ratingValueCount = 0;
                    decimal reviewCount = beer.Reviews.Count;

                    Dictionary<string, int> categoryCounts = new Dictionary<string, int>();

                    // Count the number of times each category appears in the reviews
                    foreach (var review in beer.Reviews)
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

                    //// Update the Rating property
                    //decimal totalRating = Math.Round
                    //(ratingValueCount / reviewCount, 1);
                    //beer.Rating = (double)totalRating;

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
                    beer.Rating = (double)totalRating;

                    // Update the GoesWellWith property
                    beer.GoesWellWith = string.Join(", ", mostSelectedCategories);
                }
            }

            await database.SaveChangesAsync();
        }

        public async Task OnPostAsync(string searchInput)
        {
            IQueryable<Beer> beers2Show = database.Beers;

            if (!string.IsNullOrEmpty(FindBeer))
            {
                beers2Show = beers2Show.Where(b => b.Name.Contains(FindBeer));
            }

            if (!string.IsNullOrEmpty(searchInput))
            {
                beers2Show = beers2Show.Where(b => b.Name.Contains(searchInput) || b.EAN13 == searchInput);
            }

            if (BeerType != null && BeerType.Length > 0)
            {
                List<string> types = new List<string>();
                if (BeerType.Contains("Ale"))
                {
                    types.AddRange(new string[] { "Ale", "Brown Ale", "IPA", "Wheat Ale", "Belgian Ale", "Saison" });
                }
                if (BeerType.Contains("Lager"))
                {
                    types.AddRange(new string[] { "Lager", "Kolsch", "STUFF HERE", "SORTER NÄR SOM NU" });
                }
                if (BeerType.Contains("Stout"))
                {
                    types.AddRange(new string[] { "Stout", "Imperial Stout", "PUT THING HERE", "PUT IT HERE YES" });
                }
                beers2Show = beers2Show.Where(b => types.Contains(b.Type));
            }

            Beer = await beers2Show.ToListAsync();
        }
    }
}
