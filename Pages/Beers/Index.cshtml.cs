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
                /* Beer = await database.Beers
                    .Where(b => b.Name.Contains(findBeer))
                    .ToListAsync();
                */

                beers2Show = beers2Show.Where(b => b.Name.Contains(findBeer));
            }
            else
            {
                Beer = await database.Beers.ToListAsync();
            }

            if (beerType != null && beerType.Any())
            {
                beers2Show = beers2Show.Where(b => beerType.Contains(b.Type));
            }

            Beer = await beers2Show.ToListAsync();
        }

    }
}
