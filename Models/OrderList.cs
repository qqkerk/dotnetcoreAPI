using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingstonAPI.Models
{
    public partial class OrderList
    {
        public OrderList()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Required]
        [MaxLength(50, ErrorMessage = "OId cannot be longer than 50 characters")]
        public string OId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "CId cannot be longer than 50 characters")]
        public string CId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime? DeliveryDate { get; set; }

        public CustomerList C { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
