using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    public class AirCraft
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }

        // Foreign Key
        public int AirlineId { get; set; }
        public virtual Airline Airline { get; set; }

        // Relations
        public virtual Crew Crew { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
