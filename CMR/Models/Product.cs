using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMR.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Relations
        public List<SalesOrder> salesOrder { get; set; }
    }
}
