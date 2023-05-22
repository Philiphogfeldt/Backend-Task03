﻿using System.ComponentModel.DataAnnotations;

namespace Backend_Task03.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int Rating { get; set; }
		[StringLength(180, ErrorMessage = "Comment must be at most 180 characters long.")]
		public string? Comment { get; set; }
        public DateTime Created { get; set; }
        public Account Account { get; set; }
        public Beer Beer { get; set; }
        public List<FoodCategory> FoodCategories { get; set; } = new List<FoodCategory>();
	}
}