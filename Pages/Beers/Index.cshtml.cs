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
                beers2Show = beers2Show.Where(b => beerType.Contains(b.Type));

                if (beerType.Contains("Ale"))
                {
                    beers2Show = beers2Show.Where(b => b.Type == "Ale" || b.Type == "Brown Ale" || b.Type == "IPA" || b.Type == "Wheat Ale" || b.Type == "Belgian Ale" || b.Type == "Saison");
                }

                if (beerType.Contains("Lager"))
                {
                    beers2Show = beers2Show.Where(b => b.Type == "Lager" || b.Type == "Kolsch" || b.Type == "STUFF HERE" || b.Type == "SORTER NÄR SOM NU");
                }

                if (beerType.Contains("Stout"))
                {
                    beers2Show = beers2Show.Where(b => b.Type == "Stout" || b.Type == "Imperial Stout" || b.Type == "PUT THING HERE" || b.Type == "PUT IT HERE YES");
                }
            }

            Beer = await beers2Show.ToListAsync();
        }

    }
}
