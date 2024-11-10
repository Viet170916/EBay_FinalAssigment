namespace API.Data.DTOs;

public class FavoriteDto
{
  public int FavoriteId { get; set; }
  public int? MemberId { get; set; }
  public int? ProductId { get; set; }
  public DateTime AddedDate { get; set; }
}
