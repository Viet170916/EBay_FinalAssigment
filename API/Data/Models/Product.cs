using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Models;

public class Product
{
  public int Id { get; set; }

  [MaxLength(225)]
  public string Title { get; set; }

  [MaxLength(100)]
  public string Name { get; set; }

  [MaxLength(550)]
  public string Address { get; set; }

  [MaxLength(20)]
  public string Zipcode { get; set; }

  [MaxLength(100)]
  public string City { get; set; }

  [MaxLength(100)]
  public string Country { get; set; }

  [ForeignKey("User")]
  public string UserId { get; set; }

  [Column(TypeName = "decimal(18, 2)")]
  public decimal Total { get; set; }

  public DateTime CreateAt { get; set; } = DateTime.Now;
  public User User { get; set; }
}