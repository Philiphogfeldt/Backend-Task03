using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Backend_Task03.Data;
using Backend_Task03.Models;
using Backend_Task03.Utilities;

namespace Backend_Task03.Pages.Beers
{
    public class CreateModel : PageModel
    {
        private readonly Backend_Task03.Data.AppDbContext database;
		private readonly FileRepository uploads;
		private readonly AccessControl accessControl;


		public CreateModel(Backend_Task03.Data.AppDbContext context)
        {
            database = context;
			this.uploads = uploads;
			this.accessControl = accessControl;

		}

		[BindProperty]
        public Beer Beer { get; set; } = default!;

        public IActionResult OnGet(bool generateEAN13 = false)
        {
            Beer = new Beer { EAN13 = EAN13.GenerateEAN13() };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || database.Beers == null || Beer == null)
            {
                return Page();
            }

            //Beer.Percentage = Beer.Percentage.ToString() + "%";
            Beer.EAN13 = EAN13.GenerateEAN13();
            database.Beers.Add(Beer);
            await database.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
		public List<string> PhotoURLs { get; set; } = new List<string>();

		public void OnGetPhoto()
		{
			string userFolderPath = Path.Combine(
				uploads.FolderPath,
				accessControl.LoggedInAccountID.ToString()
			);
			Directory.CreateDirectory(userFolderPath);
			string[] files = Directory.GetFiles(userFolderPath);
			foreach (string file in files)
			{
				string url = uploads.GetFileURL(file);
				PhotoURLs.Add(url);
			}
		}

		public async Task<IActionResult> OnPostPhoto(IFormFile photo)
		{
			string path = Path.Combine(
				accessControl.LoggedInAccountID.ToString(),
				Guid.NewGuid().ToString() + "-" + photo.FileName
			);
			await uploads.SaveFileAsync(photo, path);
			return RedirectToPage();
		}
	}
}
