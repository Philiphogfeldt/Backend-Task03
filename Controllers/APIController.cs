using Backend_Task03.Data;
using Backend_Task03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace Backend_Task03.Controllers
{
    [Route("/api")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly AppDbContext database;

        public APIController(AppDbContext database)
        {
            this.database = database;
        }

        public Beer GetBeer(string category)
        {
            // Retrieve the beer from the database based on the "goesWellWith" value
            // Replace this with your actual database query implementation

            var beers = database.Beers.Where(b => b.GoesWellWith.Contains(category)).ToList();

            if (beers.Count == 0)
            {
                return null; // No beers found for the given category
            }

            var random = new Random();
            var randomIndex = random.Next(0, beers.Count);
            var randomBeer = beers[randomIndex];

            return randomBeer;
        }

        public string GetImageUrl ()
        {
            var imageFiles = Directory.GetFiles("wwwroot/beerimg");

            if (imageFiles.Length == 0)
            {
                return null; // No images available
            }

            // Randomly select an image file name
            var random = new Random();
            var randomIndex = random.Next(0, imageFiles.Length);
            var randomImageFileName = Path.GetFileName(imageFiles[randomIndex]);

            // Construct the image URL based on the randomly selected image file name

            //Correct for deployment
            var imageUrl = $"https://beerlyazurewebsites.net/beerimg/{randomImageFileName}";

            //Test: Works only in dev
            //var imageUrl = $"https://localhost:5000//beerimg/{randomImageFileName}";

            return imageUrl;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string category)
        {
            var beer = GetBeer(category);

            if (beer == null)
            {
                return NotFound(); // Return a 404 Not Found response if the beer is not found
            }

            // Get a random image URL
            var imageUrl = GetImageUrl();

            // Extract only the desired properties from the beer object
            var beerResponse = new
            {
                Name = beer.Name,
                Description = beer.Description,
                Type = beer.Type,
                Percentage = beer.Percentage,
                Brewery = beer.Brewery,
                Country = beer.Country,
                GoesWellWith = beer.GoesWellWith,
                ImageUrl = imageUrl
            };

            return Ok(beerResponse);

        }



    }
}
