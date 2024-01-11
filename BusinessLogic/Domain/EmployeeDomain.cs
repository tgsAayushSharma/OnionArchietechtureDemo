using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Domain
{
    public class EmployeeDomain
    {
        private HashSet<EmployeeDomain> EmployeeDomains { get; set; }

        public EmployeeDomain()
        {
            EmployeeDomains = new HashSet<EmployeeDomain>();
        }

        public EmployeeDomain(int id, string firstName, string lastName, string email, string gender, bool? maritalStatus, DateTime? birthDate, string hobbies, string? photo,
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

        public int Id { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }
        public string? Gender { get; private set; }
        public bool? MaritalStatus { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string? Hobbies { get; private set; }
        public string? Photo { get; private set; }
        public decimal? Salary { get; private set; }
        public string? Address { get; private set; }
        public int? Country { get; private set; }
        public int? State { get; private set; }
        public int? City { get; private set; }
        public string? ZipCode { get; private set; }
        public string? Password { get; private set; }
        public DateTime? Created { get; private set; }

        public List<EmployeeDomain> employeeDomains
        {
            get
            {
                if (EmployeeDomains != null)
                {
                    return EmployeeDomains.ToList();
                }
                return employeeDomains.ToList();
            }
        }

        public void AddEmployeesDomain(int id, string? firstName, string? lastName, string? email, string? gender, bool? maritalStatus, DateTime? birthDate, string? hobbies,
         string? Photo, decimal? salary, string? address, int? country, int? state, int? city, string? zipCode, string? password, DateTime? created)
        {
            EmployeeDomains.Add(new EmployeeDomain(id, firstName, lastName, email, gender, maritalStatus, birthDate, hobbies, Photo, salary, address, country,
                    state, city, zipCode, password, created));
        }

        // public EmployeeDomain AddEmployeeImage(int id, IFormFile photo)
        // {
        //     var empdomain = EmployeeDomains.Where(x => x.Id == id).FirstOrDefault();

        //     var filename = GetFileNameFromImage(photo);

        //     empdomain.Photo = filename;

        //     return empdomain;
        // }

        // private string GetFileNameFromImage(IFormFile photo)
        // {
        //     //create path for Image upload.
        //     string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
        //     if (!Directory.Exists(path))
        //         Directory.CreateDirectory(path);

        //     //extracting file info
        //     FileInfo fileInfo = new FileInfo(photo.FileName);
        //     string fileName = photo.FileName + fileInfo.Extension;

        //     string fileNameWithPath = Path.Combine(path, fileName);

        //     //copy file to filestream
        //     using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
        //     {
        //         photo.CopyTo(stream);
        //     }

        //     long length = photo.Length;
        //     if (length < 0)
        //         throw new Exception("file is empty");

        //     // using var fileStream = photo.OpenReadStream();
        //     // byte[] bytes = new byte[length];
        //     // fileStream.Read(bytes, 0, (int)photo.Length);

        //     return fileNameWithPath;
        // }
    }
}