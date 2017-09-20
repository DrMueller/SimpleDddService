using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Application.Dtos;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;
using SimpleDddService.Infrastructure.DataAccess.Repositories;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices.Implementation
{
    public class IndividualSearchAppService : IIndividualSearchAppService
    {
        private readonly IRepository<Individual> _individualRepository;
        private readonly IMapper _mapper;

        public IndividualSearchAppService(IMapper mapper, IRepositoryFactory repositoryFactory)
        {
            _mapper = mapper;
            _individualRepository = repositoryFactory.CreateRepository<Individual>();
        }

        public async Task<IReadOnlyCollection<IndividualDto>> GetAllIndividualsAsync()
        {
            var individuals = await _individualRepository.LoadAllAsync();
            var result = _mapper.Map<List<IndividualDto>>(individuals);

            return result;
        }

        public async Task<IndividualDto> GetIndividualByIdAsync(string id)
        {
            var individual = await _individualRepository.LoadByIdAsync(id);
            var result = _mapper.Map<IndividualDto>(individual);

            return result;
        }
    }
}