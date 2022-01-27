using System.Collections.Generic;
using System.Linq;

namespace EmployeeApi.Models
{
    public class EmployeeRepository
    {
        private List<Employee> _list;

        public EmployeeRepository()
        {
            _list = new List<Employee>() { 
                new Employee 
                {
                    Id = 1,
                    Name = "Joe Doe",
                    City = "Berlin"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Mary Smith",
                    City = "Paris"
                },
            };
        }
        public List<Employee> GetAll()
        {
            return _list;
        }

        public Employee Get( int id )
        {
            return _list.First( i => i.Id == id);
        }

        public bool Add(Employee newEmployee)
        {
            if (!_list.Any(e => e.Id == newEmployee.Id)) 
            { 
                _list.Add(newEmployee);
            }

            return true;
        }

        public bool Remove(int id)
        {
            if (_list.Any(e => e.Id == id))
            {
                var employee = Get(id);
                _list.Remove(employee);
            }

            return true;
        }
    }
}
