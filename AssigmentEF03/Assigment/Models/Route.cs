using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }
        public string Classification { get; set; }
        public int NumOfPassengers { get; set; }
        public decimal Price { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public TimeSpan Duration { get; set; }

        // Foreign Key
        public int AirCraftId { get; set; }
        public virtual AirCraft AirCraft { get; set; }
    }
}
