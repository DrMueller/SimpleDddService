using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;
using SimpleDddService.Areas.IndividualManagement.Application.AppServices;

namespace SimpleDddService.Areas.IndividualManagement.Web.Controllers
{
    [Authorize]
    [Route("api/IndividualManagement/Individuals")]
    public class AddressesController : Controller
    {
        private readonly IIndividualAddressAppService _individualAddressAppService;

        public AddressesController(IIndividualAddressAppService individualAddressAppService)
        {
            _individualAddressAppService = individualAddressAppService;
        }

        [HttpPost("{individualId}/Addresses")]
        public async Task<IActionResult> AddOrUpdateAddressAsync([FromRoute] string individualId, [FromBody] AddressAppDto dto)
        {
            var result = await _individualAddressAppService.AddOrUpdateAddressAsync(individualId, dto);
            return Ok(result);
        }

        [HttpGet("{individualId}/Addresses")]
        [Authorize]
        public async Task<IActionResult> GetAllAddresses([FromRoute] string individualId)
        {
            var result = await _individualAddressAppService.GetAllAddressesAsync(individualId);
            return Ok(result);
        }

        [HttpGet("{individualId}/Addresses/Test")]
        public IActionResult GetTestAddress()
        {
            var result = new AddressAppDto
            {
                AddressType = AddressTypeAppDto.Private,
                City = "Fake Town",
                Street = "Fake Street",
                Zip = "1715"
            };

            return Ok(result);
        }
    }
}