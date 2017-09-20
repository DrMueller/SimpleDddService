using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleDddService.Areas.IndividualManagement.Application.AppServices;
using SimpleDddService.Areas.IndividualManagement.Application.Dtos;

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
            IExternalCallAppService externalCallAppService)
        {
            _individualCrudAppService = individualCrudAppService;
            _individualSearchAppService = individualSearchAppService;
            _externalCallAppService = externalCallAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndividualAsync([FromBody] NewIndividualDto dto)
        {
            var result = await _individualCrudAppService.CreateIndividualAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIndividuals()
        {
            var result = await _individualSearchAppService.GetAllIndividualsAsync();
            return Ok(result);
        }

        [HttpGet("ExternalRestCall")]
        public async Task<IActionResult> GetFromExternalRestCallAsync()
        {
            var firstPost = await _externalCallAppService.GetFirstPostAsync();
            return Ok(firstPost);
        }

        [HttpGet("{individualId}")]
        public async Task<IActionResult> GetIndividual([FromRoute] string individualId)
        {
            var result = await _individualSearchAppService.GetIndividualByIdAsync(individualId);
            return Ok(result);
        }

        [HttpGet("Test")]
        public IActionResult GetTestIndividual()
        {
            var result = new IndividualDto
            {
                FirstName = "Matthias",
                Gender = IndividualGenderDto.Male,
                Id = "Tra124",
                LastName = "Müller"
            };

            return Ok(result);
        }
    }
}