using System;
using System.Collections.Generic;
using System.Text;

namespace AppCampusPartyDemo.Models
{
    public class Summary
    {
        public string date { get; set; }
        public decimal opening { get; set; }
        public decimal closing { get; set; }
        public string lowest { get; set; }
        public string highest { get; set; }
        public string volume { get; set; }
        public string quantity { get; set; }
        public string amount { get; set; }
        public string avg_price { get; set; }
    }
}
