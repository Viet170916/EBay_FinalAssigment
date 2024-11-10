namespace API.Data.DTOs;

public class OrderDto
{
  public int OrderId;
  public int ReviewId { get; set; }
  public int ProductId { get; set; }
  public int MemberId { get; set; }
  public int Rating { get; set; }
  public string Comment { get; set; }
  public DateTime ReviewDate { get; set; }
  public DateTime OrderDate { get; set; }
  public DateTime RequiredDate { get; set; }
  public DateTime? ShippedDate { get; set; }
  public decimal Freight { get; set; }
}
