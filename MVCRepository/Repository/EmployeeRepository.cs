using MVCRepository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MVCRepository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int EmpId)
        {
            return _context.Employees.Find(EmpId);
        }

        public int AddEmployee(Employee employee)
        {
            int result = -1;
            if (employee != null)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                result = employee.EmployeeId;
            }
            return result;
        }

        public int UpdateEmployee(Employee employee)
        {
            int result = -1;
            if (employee != null)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
                result = employee.EmployeeId;
            }
            return result;
        }

        public void DeleteEmployee(int empId)
        {
            Employee employee = _context.Employees.Find(empId);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                { _context.Dispose(); }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}