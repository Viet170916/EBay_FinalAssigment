using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StripeId { get; set; }  // ID thanh toán từ Stripe

        [Required]
        public int UserId { get; set; }  // ID người dùng đã đặt hàng

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }  // Tổng tiền của đơn hàng

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;  // Thời gian tạo đơn hàng

        // Thông tin địa chỉ giao hàng
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
