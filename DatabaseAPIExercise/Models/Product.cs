using System;
using System.Collections.Generic;

namespace DatabaseAPIExercise.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
