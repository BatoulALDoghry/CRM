using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMR.Models
{
    public class SalesOrderHeader
    {
        //        •	Sales order id: auto number primary key
        //•	Sales order status
        //•	Sales order date
        //•	Sales order customer id
        //•	Sales order tax(USE VAT 14% as TAX)
        //•	Sales subtotal(items total summation)
        //•	Sales grand total(subtotal – VAT)
        //•	Sales order shipping address info(address id, address line 1, address line 2, city, state, postal code and country)
        //•	Sales order billing address info(address id, address line 1, address line 2, city, state, postal code and country)
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public Double Tax { get; set; }
        public Double SubTotal { get; set; }
        public Double GrandTotal { get; set; }
        public SalesOrderShipping Sales_Order_Shipping { get; set; }
        public SalesOrderBilling Sales_Order_Billing { get; set; }

        public int? CustomerId { get; set; } //FK
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        //Relations
        public List<SalesOrder> salesOrder { get; set; }
    }
}
