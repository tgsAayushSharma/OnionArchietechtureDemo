using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public bool? MaritalStatus { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Hobbies { get; set; }
        public string? Photo { get; set; }
        public decimal? Salary { get; set; }
        public string? Address { get; set; }
        public int? Country { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Password { get; set; }
        public DateTime? Created { get; set; }
    }
}
