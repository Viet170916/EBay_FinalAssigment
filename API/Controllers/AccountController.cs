using API.BU.Services.Interfaces;
using API.Data.Models;
using API.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController(IUserRepository userRepository, IUserService userService) : ControllerBase
{
  [HttpPost("login")] public async Task<IActionResult> Login([FromBody] LoginModel model)
  {
    var user = await userRepository.GetAllQueryable().FirstOrDefaultAsync(u => u.SupabaseId == model.SupabaseId);
    if (user == null)
    {
      await userRepository.Add(new User()
      {
        Role = model.Role ?? "Buyer", SupabaseId = model.SupabaseId, Username = model.SupabaseId
      });
      return Ok(new { Token = userService.GenerateToken(model.SupabaseId, model.Role), Message="Register Successfully", });
    }

    var token = userService.GenerateToken(user.SupabaseId, user.Role);
    return Ok(new { Token = token });
  }
}

public class RegisterModel
{
  public string Username { get; set; }
  public string SupabaseId { get; set; }
}

public class LoginModel
{
  public string Username { get; set; }
  public string SupabaseId { get; set; }
  public string? Role { get; set; }
}