namespace API.Data.DTOs;

public class PromotionDto
{
  public int PromotionId { get; set; }
  public int ProductId { get; set; }
  public decimal Discount { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public string PromotionCode { get; set; }
}