using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Orders;

namespace TestSolutions.Domain.Employees
{
    public class Employee
    {
        public Employee()
        {
            this.Orders = new List<Order>();
        }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
