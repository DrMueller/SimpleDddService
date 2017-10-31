using System.Threading.Tasks;
using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;
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

        public async Task<IndividualAppDto> CreateIndividualAsync(NewIndividualAppDto dto)
        {
            var individual = _mapper.Map<Individual>(dto);
            return await SaveIndividualAsync(individual);
        }

        public async Task DeleteIndividualAsync(string individualId)
        {
            await _individualRepository.DeleteAsync(individualId);
        }

        public async Task<IndividualAppDto> UpdateIndividualAsync(IndividualAppDto dto)
        {
            var individual = _mapper.Map<Individual>(dto);
            return await SaveIndividualAsync(individual);
        }

        private async Task<IndividualAppDto> SaveIndividualAsync(Individual individual)
        {
            var createdIndividual = await _individualRepository.SaveAsync(individual);
            var result = _mapper.Map<IndividualAppDto>(createdIndividual);
            return result;
        }
    }
}