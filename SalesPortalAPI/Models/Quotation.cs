using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPortalAPI.Models
{
    public class Quotation
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string DealerName { get; set; }
        public DateTime DateOfQuotation { get; set; }
        public DateTime ValidUntil { get; set; }
    }
   
}
