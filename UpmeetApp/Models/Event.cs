using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetApp.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
    }
}
