using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class StripeController: ControllerBase

{
  [HttpPost]
  [Authorize] 
  public async Task<IActionResult> CreatePaymentIntent([FromBody] PaymentRequest request)
  {
    try
    {
      var options = new PaymentIntentCreateOptions
      {
        Amount = request.Amount,
        Currency = "USD",
        AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
        {
          Enabled = true,
        },
      };

      var service = new PaymentIntentService();
      var paymentIntent = await service.CreateAsync(options);

      return Ok(paymentIntent);
    }
    catch (System.Exception ex)
    {
      return BadRequest(new { error = ex.Message });
    }
  }
}

public class PaymentRequest
{
  public long Amount { get; set; }
}