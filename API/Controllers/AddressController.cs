using API.Data.Models;
using API.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressController(IGenericRepository<Address> repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await repository.GetAll();
            return Ok(addresses);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAddress(AddressRequest addressRequest)
        {
            var address = new Address()
            {
                Name = addressRequest.Name,
                AddressLine = addressRequest.AddressLine,
                Zipcode = addressRequest.Zipcode,
                City = addressRequest.City,
                Country = addressRequest.Country,
                UserId = addressRequest.UserId
            };
            await repository.Add(address);
            return Ok(new { Message = "Create Successfully" });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAddress(AddressRequest addressRequest)
        {
            var address = new Address()
            {
                Id = addressRequest.Id ?? 0,
                Name = addressRequest.Name,
                AddressLine = addressRequest.AddressLine,
                Zipcode = addressRequest.Zipcode,
                City = addressRequest.City,
                Country = addressRequest.Country,
                UserId = addressRequest.UserId
            };
            await repository.Update(address);
            return Ok(new { Message = "Update Successfully" });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            await repository.Remove(addressId);
            return Ok(new { Message = "Delete Successfully" });
        }
    }

    public class AddressRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int UserId { get; set; }
    }
}
