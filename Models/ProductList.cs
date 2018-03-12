using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingstonAPI.Models
{
    public partial class ProductList
    {
        public ProductList()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Required]
        [MaxLength(50, ErrorMessage = "PId cannot be longer than 50 characters")]
        public string PId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "PName cannot be longer than 100 characters")]
        public string PName { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage ="PDescription cannot be longer than 500 characters")]
        public string PDescription { get; set; }

        [Required]
        public decimal PPrice { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
