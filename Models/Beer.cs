﻿using System.ComponentModel.DataAnnotations;

namespace Backend_Task03.Models
{
    public class Beer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double? Percentage { get; set; }
        public string Brewery { get; set; }
        public string Country { get; set; }
		[RegularExpression("^[0-9]+$", ErrorMessage = "Only numbers are allowed.")]
		public string EAN13 { get; set; }
        public string? GoesWellWith { get; set; } = "-";
        public double? Rating { get; set; }
        public List<Review>? Reviews { get; set; }

        //account kan inte creata ny review om man redan har en review på den ölen
    }
}
