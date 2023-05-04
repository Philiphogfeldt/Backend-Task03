using Backend_Task03.Data;
using Backend_Task03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Backend_Task03.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext database;

        public IndexModel(AppDbContext database)
        {
            this.database = database;
        }

        public void OnGet()
        {
        }

    }
}