using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Domain;
using DataAccess.DataActions.Interface;
using Microsoft.AspNetCore.Http;
using Service.Interface;
using Service.Mappers.Interface;
using Service.ViewModels;

namespace Service
{
    public class ServicesClass : IServices
    {
        private readonly IDataAction _dataAction;
        private readonly IDtoToEntityMappers _dtoToEntityMapper;
        private readonly IDtoToDomainMappers _dtoToDomainMapper;
        private readonly IDomainToEntityMappers _domainToEntityMapper;

        public ServicesClass(IDataAction dataAction, IDtoToEntityMappers dtoToEntityMappers, IDtoToDomainMappers dtoToDomainMappers, IDomainToEntityMappers domainToEntityMappers)
        {
            _dataAction = dataAction;
            _dtoToEntityMapper = dtoToEntityMappers;
            _dtoToDomainMapper = dtoToDomainMappers;
            _domainToEntityMapper = domainToEntityMappers;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _dataAction.GetAllEmployees();

            var employeeDto = _dtoToEntityMapper.ConvertEmployeesEntityToDto(employees);

            return employeeDto;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var employeeEntity = _dataAction.GetEmployeeById(id);

            var employeeDto = _dtoToEntityMapper.ConvertEmployeeEntityToDto(employeeEntity);

            return employeeDto;
        }

        public string AddEmployee(EmployeeDto employeeDto, IFormFile? photo)
        {
            var employeeDomain = _dtoToDomainMapper.ConvertEmployeeDtoToDomain(employeeDto);

            // var employee = employeeDomain.AddEmployeeImage(employeeDto.Id, photo);

            var employeeEntity = _domainToEntityMapper.ConvertEmployeeDomainToEntity(employeeDomain);

            employeeEntity.Photo = GetFileNameFromImage(photo);

            _dataAction.AddEmployee(employeeEntity);

            return "Success";
        }

        public void UpdateEmployee(EmployeeDto employeeDto)
        {
            var employeeEntity = _dtoToEntityMapper.ConvertEmployeeDtoToEntity(employeeDto);

            _dataAction.UpdateEmployee(employeeEntity);
        }

        public void DeleteEmployee(int id)
        {
            var employeeEntity = _dataAction.GetEmployeeById(id);

            _dataAction.DeleteEmployee(employeeEntity);

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