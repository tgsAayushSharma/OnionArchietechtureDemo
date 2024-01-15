using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DataActions.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Service.Interface;
using Service.ViewModels;

namespace Service
{
    public class ServicesClass : IServices
    {
        private readonly IDataAction<Employee> _dataAction;

        public ServicesClass(IDataAction<Employee> dataAction)
        {
            _dataAction = dataAction;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dataAction.GetAll();
        }

        public Employee GetEmployeeById(int id)
        {
            return _dataAction.GetById(id);
        }

        public void AddEmployee(Employee employee, IFormFile? photo)
        {
            employee.Photo = GetFileNameFromImage(photo);

            _dataAction.AddData(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _dataAction.UpdateData(employee);
        }

        public void DeleteEmployee(int id)
        {
            _dataAction.DeleteData(id);

        }

        private string GetFileNameFromImage(IFormFile photo)
        {
            //create path for Image upload.
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //extracting file info
            FileInfo fileInfo = new FileInfo(photo.FileName);
            string fileName = photo.FileName + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            //copy file to filestream
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                photo.CopyTo(stream);
            }

            long length = photo.Length;
            if (length < 0)
                throw new Exception("file is empty");

            // using var fileStream = photo.OpenReadStream();
            // byte[] bytes = new byte[length];
            // fileStream.Read(bytes, 0, (int)photo.Length);

            return fileNameWithPath;
        }
    }
}