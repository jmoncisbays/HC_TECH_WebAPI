using System.Collections.Generic;
using HC_TECH_WebAPI.Models;

namespace HC_TECH_WebAPI.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll { get; }
        Employee Get(int id);
        void Add(Employee employee) ;
        void Update(int id, Employee employee);
        void Delete(int id);
    }
}
