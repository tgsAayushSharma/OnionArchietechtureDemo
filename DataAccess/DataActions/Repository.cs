using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DataActions.Interface;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DataAccess.DataActions
{
    public class Repository<T> : IRepository<T> where T : Employee
    {
        private readonly EmployeeContext _context;
        private DbSet<T> entities;

        public Repository(EmployeeContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable() ??
            throw new Exception("No Data Found!");
        }

        public T GetById(int id)
        {
            return entities.FirstOrDefault(x => x.Id == id) ??
                throw new Exception("No Data found with the given id.");
        }

        public void AddData(T entity)
        {
            if (entity == null) throw new ArgumentException("Entity is null.");
            entity.Created = DateTime.Now;

            entities.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateData(T entity)
        {
            var existing = entities.FirstOrDefault(x => x.Id == entity.Id) ??
                throw new Exception("No Data found with the given identifier.");

            _context.Entry(existing).State = EntityState.Modified;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void DeleteData(T entity)
        {
            var existing = entities.FirstOrDefault(x => x.Id == entity.Id) ??
                throw new Exception("No data found with the given identifier.");

            _context.Entry(existing).State = EntityState.Deleted;
            entities.Remove(existing);
            _context.SaveChanges();
        }
    }
}