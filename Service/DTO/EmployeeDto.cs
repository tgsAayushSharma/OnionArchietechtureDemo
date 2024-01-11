using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Service.ViewModels
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }

        public EmployeeDto(int id, string firstName, string lastName, string email, string gender, bool? maritalStatus, DateTime? birthDate, string hobbies, string? photo,
                      decimal? salary, string address, int? country, int? state, int? city, string zipCode, string password, DateTime? created)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            MaritalStatus = maritalStatus;
            BirthDate = birthDate;
            Hobbies = hobbies;
            Photo = photo;
            Salary = salary;
            Address = address;
            Country = country;
            State = state;
            City = city;
            ZipCode = zipCode;
            Password = password;
            Created = created;
        }
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