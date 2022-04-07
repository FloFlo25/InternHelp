using System;
namespace DatabaseAPIExercise.Models
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int MonthlyIncome { get; set; }
        public string OwnerName { get; set; }
        public DateTime ActiveSince { get; set; }
    }
}
