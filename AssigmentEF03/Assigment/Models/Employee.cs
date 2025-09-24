using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Qualifications { get; set; }
        public string Address { get; set; }

        // Foreign Key
        public int AirlineId { get; set; }
        public virtual Airline Airline { get; set; }
    }
}
