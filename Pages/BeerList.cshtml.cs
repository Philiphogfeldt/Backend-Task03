using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Backend_Task03.Models;
using Backend_Task03.Data;


namespace Backend_Task03.Pages
{
    public class BeerListModel : PageModel
    {
        private readonly AppDbContext database;

        public BeerListModel(AppDbContext context)
        {
            database = context;
        }

        public IList<Beer> Beers { get; set; }

        public void OnGet()
        {
            Beers = database.Beers.ToList();
        }
    }
}
