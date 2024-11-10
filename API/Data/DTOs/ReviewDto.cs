namespace API.Data.DTOs;

public class ReviewDto
{
  public int ReviewId { get; set; }
  public int ProductId { get; set; }
  public int MemberId { get; set; }
  public int Rating { get; set; }
  public string Comment { get; set; }
  public DateTime ReviewDate { get; set; }
}
