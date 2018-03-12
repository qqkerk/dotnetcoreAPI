using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingstonAPI.Models
{
    public partial class OrderDetail
    {
        [Required]
        [MaxLength(50, ErrorMessage = "OId cannot be longer than 50 characters")]
        public string OId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "OId cannot be longer than 50 characters")]
        public string PId { get; set; }

        [Required]
        public int OrderNumber { get; set; }

        public OrderList O { get; set; }
        public ProductList P { get; set; }
    }
}
