using API.BU.Services.Interfaces;
using API.Data.Models;
using API.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(IOrderService service, IOrderRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await repository.GetAll();
        return Ok(orders);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder(OrderRequest orderRequest)
    {
        var order = new Order()
        {
            StripeId = orderRequest.StripeId,
            UserId = orderRequest.UserId,
            Total = orderRequest.Total,
            CreatedAt = DateTime.Now,
            Name = orderRequest.Name,
            Address = orderRequest.Address,
            Zipcode = orderRequest.Zipcode,
            City = orderRequest.City,
            Country = orderRequest.Country
        };
        await repository.Add(order);
        return Ok(new { Message = "Order created successfully" });
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateOrder(OrderRequest orderRequest)
    {
        var order = new Order()
        {
            Id = orderRequest.Id ?? 0,
            StripeId = orderRequest.StripeId,
            UserId = orderRequest.UserId,
            Total = orderRequest.Total,
            Name = orderRequest.Name,
            Address = orderRequest.Address,
            Zipcode = orderRequest.Zipcode,
            City = orderRequest.City,
            Country = orderRequest.Country
        };
        await repository.Update(order);
        return Ok(new { Message = "Order updated successfully" });
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteOrder(int orderId)
    {
        await repository.Remove(orderId);
        return Ok(new { Message = "Order deleted successfully" });
    }
}
public class OrderRequest
{
    public int? Id { get; set; }               // ID của đơn hàng (chỉ dùng cho cập nhật)
    public string StripeId { get; set; }       // ID thanh toán Stripe
    public int UserId { get; set; }            // ID người dùng
    public decimal Total { get; set; }         // Tổng tiền đơn hàng
    public string Name { get; set; }           // Tên người nhận
    public string Address { get; set; }        // Địa chỉ giao hàng
    public string Zipcode { get; set; }        // Mã bưu điện
    public string City { get; set; }           // Thành phố
    public string Country { get; set; }        // Quốc gia
}
