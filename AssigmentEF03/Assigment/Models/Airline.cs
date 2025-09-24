using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    public class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phones { get; set; }
        public string ContactPerson { get; set; }

        // Relationships
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<AirCraft> AirCrafts { get; set; }
    }
}
