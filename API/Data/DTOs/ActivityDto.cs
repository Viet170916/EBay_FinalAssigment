namespace API.Data.DTOs;

public class ActivityDto
{
  public int ActivityId { get; set; }
  public int MemberId { get; set; }
  public string ActivityType { get; set; }
  public DateTime ActivityDate { get; set; }
  public string Description { get; set; }
}
