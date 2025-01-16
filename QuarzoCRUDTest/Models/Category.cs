using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuarzoCRUDTest.Models
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required]
        public bool Active { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}