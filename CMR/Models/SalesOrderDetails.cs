using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMR.Models
{
    public class SalesOrderDetails
    {
        //        •	Sales order id
        //•	Sales order line no
        //•	product id
        //•	line price
        //•	line ordered qty
        //•	line tax amount
        //•	line total(auto calculated: qty* price)
        [Key]
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public double LinePrice { get; set; }
        public int LineOrderdQty { get; set; }
        public double TaxAmount { get; set; }
        public double Total { get { return LineOrderdQty * LinePrice; } set { } }

        public int? ProductId { get; set; } //FK
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Relations
        public List<SalesOrder> salesOrder { get; set; }
    }
}
