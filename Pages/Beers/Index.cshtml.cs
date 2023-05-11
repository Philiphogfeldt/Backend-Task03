using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Backend_Task03.Data;
using Backend_Task03.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend_Task03.Pages.Beers
{
	public class IndexModel : PageModel
	{
		private readonly Backend_Task03.Data.AppDbContext database;

		public IndexModel(Backend_Task03.Data.AppDbContext context)
		{
			database = context;
		}

		public IList<Beer> Beer { get; set; }

		//public string Goesw { get; set; }

		[BindProperty(SupportsGet = true)]
		public string Chicken { get; set; }
		public string Meat { get; set; }
		public string Fish { get; set; }
		public string Vegetarian { get; set; }
		public string Dessert { get; set; }

		public async Task OnGetAsync()
		{
			Beer = await database.Beers.ToListAsync();

			var beers = await database.Beers.Include(b => b.Reviews).ThenInclude(r => r.FoodCategories).ToListAsync();

			foreach (var beer in beers)
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

						if (kvp.Key == Chicken)
						{

						};

					}
				}

				//Update the Rating property
				decimal totalRating = Math.Round(ratingValueCount / reviewCount, 1);
				beer.Rating = (double)totalRating;

				// Update the GoesWellWith property
				beer.GoesWellWith = string.Join(", ", mostSelectedCategories);
			}

			await database.SaveChangesAsync();
			//return View(beers);  


		}

		public async Task OnPostAsync(string findBeer, string[] beerType)
		{
			IQueryable<Beer> beers2Show = database.Beers;

			if (!string.IsNullOrEmpty(findBeer))
			{
				beers2Show = beers2Show.Where(b => b.Name.Contains(findBeer));
			}
			else
			{
				Beer = await database.Beers.ToListAsync();
			}
			if (beerType != null && beerType.Any())
			{
				List<string> types = new List<string>();
				if (beerType.Contains("Ale"))
				{
					types.AddRange(new string[] { "Ale", "Brown Ale", "IPA", "Wheat Ale", "Belgian Ale", "Saison" });
				}
				if (beerType.Contains("Lager"))
				{
					types.AddRange(new string[] { "Lager", "Kolsch", "STUFF HERE", "SORTER NÄR SOM NU" });
				}
				if (beerType.Contains("Stout"))
				{
					types.AddRange(new string[] { "Stout", "Imperial Stout", "PUT THING HERE", "PUT IT HERE YES" });
				}
				beers2Show = beers2Show.Where(b => types.Contains(b.Type));
			}

			Beer = await beers2Show.ToListAsync();
		}

	}
}
