using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;
using SimpleDddService.Areas.IndividualManagement.Application.AppServices;
using SimpleDddService.Areas.IndividualManagement.Web.Infrastructure.Extensions;

namespace SimpleDddService.Areas.IndividualManagement.Web.Controllers
{
    [Route("api/IndividualManagement/[controller]")]
    public class IndividualsController : Controller
    {
        private readonly IExternalCallAppService _externalCallAppService;
        private readonly IIndividualCrudAppService _individualCrudAppService;
        private readonly IIndividualSearchAppService _individualSearchAppService;

        public IndividualsController(
            IIndividualCrudAppService individualCrudAppService,
            IIndividualSearchAppService individualSearchAppService,
            IExternalCallAppService externalCallAppService, 
        )
        {
            _individualCrudAppService = individualCrudAppService;
            _individualSearchAppService = individualSearchAppService;
            _externalCallAppService = externalCallAppService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateIndividualAsync([FromBody] NewIndividualAppDto dto)
        {
            var result = await _individualCrudAppService.CreateIndividualAsync(dto);
            return CreatedAtRoute("GetIndividual", new { individualId = result.Id }, result);
        }

        [HttpDelete("{individualId}")]
        public async Task<IActionResult> DeleteIndividualAsync([FromRoute] string individualId)
        {
            await _individualCrudAppService.DeleteIndividualAsync(individualId);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIndividuals()
        {
            var result = await _individualSearchAppService.GetAllIndividualsAsync();
            return Ok(result);
        }

        [HttpGet("ExternalRestCall/{getResult}")]
        public async Task<IActionResult> GetFromExternalRestCallAsync([FromRoute] bool getResult)
        {
            var firstPostMaybe = await _externalCallAppService.GetOnePostAsync(getResult);
            var result = firstPostMaybe.ToGetActionResult();
            return result;
        }

        [HttpGet("{individualId}", Name = "GetIndividual")]
        public async Task<IActionResult> GetIndividual([FromRoute] string individualId)
        {
            var result = await _individualSearchAppService.GetIndividualByIdAsync(individualId);
            return Ok(result);
        }

        [HttpGet("Test")]
        public IActionResult GetTestIndividual()
        {
            var result = new IndividualAppDto
            {
                FirstName = "Matthias",
                Gender = IndividualGenderAppDto.Male,
                Id = "Tra124",
                LastName = "Müller"
            };

            return Ok(result);
        }

        [HttpPatch("{individualId}")]
        public async Task<IActionResult> PatchIndividualAsync([FromRoute] string individualId, [FromBody] JsonPatchDocument<IndividualAppDto> dto)
        {
            // For JsonPatchDocument syntax, see: https://stackoverflow.com/questions/39073424/jsonpatchdocument-not-binding-correctly 
            var existingIndividualDto = await _individualSearchAppService.GetIndividualByIdAsync(individualId);
            dto.ApplyTo(existingIndividualDto);

            var retuernedIndividualDto = await _individualCrudAppService.UpdateIndividualAsync(existingIndividualDto);
            return Ok(retuernedIndividualDto);
        }
    }
}