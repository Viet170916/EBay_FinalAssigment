namespace API.BU.Services.Interfaces;

public interface IUserService
{
  string GenerateToken(string supabaseId, string? userRole);
}