using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Models;

public class Product
{
  public int Id { get; set; }

  [MaxLength(225)]
  public string Title { get; set; }

  public string? Description { get; set; }
  public string Url { get; set; }

  [Column(TypeName = "decimal(18, 2)")]
  public decimal Price { get; set; }

  public DateTime CreateAt { get; set; } = DateTime.Now;

  [ForeignKey("User")]
  public int? UserId { get; set; }

  public User? User { get; set; }
}