using System;
using System.Collections.Generic;
using System.Linq;
using HC_TECH_WebAPI.Models;
using System.IO;
using Newtonsoft.Json;

namespace HC_TECH_WebAPI.Repositories
{
    public class JSONEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;
        private static int _employeeId;

        public JSONEmployeeRepository()
        {
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"FileStorage\employees.json");
            _employees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(jsonFilePath));

            // last employee's id
            _employeeId = _employees.LastOrDefault()?.Id ?? 0;
        }

        /// <summary>
        /// Return all the employees.
        /// </summary>
        public IEnumerable<Employee> GetAll => _employees;

        /// <summary>
        /// Add an employee.
        /// </summary>
        /// <param name="employee"></param>
        public void Add(Employee employee)
        {
            // set employee Id
            employee.Id = ++_employeeId;
            _employees.Add(employee);

            UpdateJSONFie();
        }

        /// <summary>
        /// Delete an employee by its Id. If the employee is not found, an InvalidOperationException exception is thrown.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            int index = _employees.FindIndex(e => e.Id == id);

            if (index == -1)
            {
                throw new InvalidOperationException();
            }

            _employees.RemoveAt(index);

            UpdateJSONFie();
        }

        /// <summary>
        /// Returns an employee by its Id. If the employee is not found, an InvalidOperationException exception is thrown.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee object</returns>
        public Employee Get(int id)
        {
            return _employees.First(e => e.Id == id);
        }

        /// <summary>
        /// Update an employee by its Id. If the employee is not found, an InvalidOperationException exception is thrown.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        public void Update(int id, Employee employee)
        {
            int index = _employees.FindIndex(e => e.Id == id);

            if (index == -1)
            {
                throw new InvalidOperationException();
            }

            _employees[index] = employee;

            UpdateJSONFie();
        }

        private void UpdateJSONFie()
        {
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), @"FileStorage\employees.json"), JsonConvert.SerializeObject(_employees));
        }
    }
}
