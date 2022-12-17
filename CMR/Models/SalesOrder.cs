using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMR.Models
{
    public class SalesOrder
    {
        [Key]
        public int Id { get; set; }
        public int? SalesOrderHeaderId { get; set; }
        public SalesOrderHeader Sales_Order_Header { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? SalesOrderDetailsId { get; set; }
        public SalesOrderDetails Sales_Order_Details { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
       
    }
}
