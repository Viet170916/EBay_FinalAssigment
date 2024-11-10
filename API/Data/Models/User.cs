namespace API.Data.Models;

public partial class User
{
  public int Id { get; set; }
  public string Username { get; set; } = null!;
  public string SupabaseId { get; set; } = null!;
  public string? Role { get; set; }
}