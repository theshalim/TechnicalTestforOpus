﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Models
{
    public class SalesDetail
    {
        public int Id { get; set; }

        
        public int SalesMasterId { get; set; }
        
        public int ProductId { get; set; }
        [Display(Name = "Product Id")]
        public virtual Product ProductS { get; set; }
        [Display(Name = "Sales MasterId")]
        public virtual SalesMaster SalesMasters { get; set; }


        [Required]
        public int Quantity { get; set; }

        [Required] [Display(Name = "Total Price ")]
       
        public decimal TotalPrice { get; set; }
    }
}
