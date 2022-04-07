using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAPIExercise.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Value { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}