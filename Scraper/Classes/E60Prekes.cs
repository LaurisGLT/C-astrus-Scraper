using System;
using System.Collections.Generic;
using System.Text;

namespace Scraper.Classes
{
    public class E60Prekes:BaseModel
    {
        public int Id { get; set; }
        public string product { get; set; }

        public string type { get; set; }
        public double kaina { get; set; }
        public string href { get; set; }
    }
}
