using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCRepository.Models;
namespace MVCRepository.Repository
{
    public interface IEmployeeRepository :IDisposable
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int EmpId);
        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        void DeleteEmployee(int empId);
    }
}
