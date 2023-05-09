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

        public async Task OnGetAsync()
        {
            Beer = await database.Beers.ToListAsync();


            //metod för att beräkna GoesWith
            foreach (var beer in Beer) 
            
            { 
                List<string> goesWith = new List<string>();
              
                var review = database.Reviews.Where(b => b.Beer == beer).Include(b => b.FoodCategories).ToList();

                foreach (var r in review)
                {
                    foreach (var c in r.FoodCategories)
                    {
                        goesWith.Add(c.Name);
                    }
                }



            }
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
