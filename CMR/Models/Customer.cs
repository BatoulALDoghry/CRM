using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMR.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }



        //Relations
        public int CustomerAddressId { get; set; }
        public CustomerAddress Address { get; set; }


        public List<SalesOrder> salesOrder { get; set; }
    }
}
