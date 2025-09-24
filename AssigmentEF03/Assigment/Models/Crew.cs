using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    public class Crew
    {
        public int Id { get; set; }
        public string MajPilot { get; set; }
        public string AssisPilot { get; set; }
        public string Host1 { get; set; }
        public string Host2 { get; set; }

        // Foreign Key
        public int AirCraftId { get; set; }
        public virtual AirCraft AirCraft { get; set; }
    }
}
