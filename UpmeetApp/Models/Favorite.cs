using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetApp.Models
{
    public class Favorite
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
    }
}
