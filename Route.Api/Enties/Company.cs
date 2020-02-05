using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Route.Api.Enties
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Introuduction { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}

