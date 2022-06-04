using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Models
{
    public class SalesMaster
    {
        [Key]
        public int SalesMasterId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TotalQuantity { get; set; }


        [Required]
        public decimal TotalPrice { get; set; }

        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
