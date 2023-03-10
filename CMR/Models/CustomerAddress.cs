using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMR.Models
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public int Line1 { get; set; }
        public int Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool shipping_address_flag { get; set; }
        public bool billing_address_flag { get; set; }
    }
}
