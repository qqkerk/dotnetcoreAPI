using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingstonAPI.Models
{
    public partial class CustomerList
    {
        public CustomerList()
        {
            OrderList = new HashSet<OrderList>();
        }

        [Required]
        [MaxLength(50, ErrorMessage = "CId cannot be longer than 50 characters")]
        public string CId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "CCompanyName cannot be longer than 50 characters")]
        public string CCompanyName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "CAddress cannot be longer than 100 characters")]
        public string CAddress { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "CContactName cannot be longer than 50 characters")]
        public string CContactName { get; set; }

        [Phone]
        [MaxLength(50, ErrorMessage = "CPhone cannot be longer than 50 characters")]
        public string CPhone { get; set; }

        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Email cannot be longer than 50 characters")]
        public string CEmail { get; set; }

        [MaxLength(50, ErrorMessage = "CFax cannot be longer than 50 characters")]
        public string CFax { get; set; }

        public ICollection<OrderList> OrderList { get; set; }
    }
}
