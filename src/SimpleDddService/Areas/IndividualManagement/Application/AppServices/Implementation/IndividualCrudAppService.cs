using System.Threading.Tasks;
using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Application.Dtos;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;
using SimpleDddService.Infrastructure.DataAccess.Repositories;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices.Implementation
{
    public class IndividualCrudAppService : IIndividualCrudAppService
    {
        private readonly IRepository<Individual> _individualRepository;
        private readonly IMapper _mapper;

        public IndividualCrudAppService(IMapper mapper, IRepositoryFactory repositoryFactory)
        {
            _mapper = mapper;
            _individualRepository = repositoryFactory.CreateRepository<Individual>();
        }

        public async Task<IndividualDto> CreateIndividualAsync(NewIndividualDto dto)
        {
            var individual = _mapper.Map<Individual>(dto);
            var createdIndividual = await _individualRepository.SaveAsync(individual);
            var result = _mapper.Map<IndividualDto>(createdIndividual);
            return result;
        }
    }
}