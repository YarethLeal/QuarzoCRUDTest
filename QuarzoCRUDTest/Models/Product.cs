using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuarzoCRUDTest.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}