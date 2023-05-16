using Backend_Task03.Data;
using Backend_Task03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

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


        //[HttpGet]
        //public Beer[] Get(string query)
        //{
        //    var thisBeer = database.Beers.Where(m => m.GoesWellWith.Contains(query)).ToArray(); 

        //    if (query == "Meat") 
        //    {
        //        return default;

        //    }

        //    if (completed == null)
        //    {
        //        return database.ToDoNotes.ToArray();

        //    }
        //    else if (completed == true)
        //    {
        //        return database.ToDoNotes.Where(m => m.IsDone == true).ToArray();

        //    }
        //    else if (completed == false)
        //    {
        //        return database.ToDoNotes.Where(m => m.IsDone == false).ToArray();
        //    }
        //    //kanske inte en så bra lösning
        //    else
        //    {
        //        return default;
        //    }
        //}



    }
}
