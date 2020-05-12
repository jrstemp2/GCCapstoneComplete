using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetApp.Models
{
    public class JoinedEF
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }

    }
}
