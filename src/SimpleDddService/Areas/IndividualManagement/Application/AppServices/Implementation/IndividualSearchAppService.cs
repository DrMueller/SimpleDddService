using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Application.AppDtos;
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

        public async Task<IReadOnlyCollection<IndividualAppDto>> GetAllIndividualsAsync()
        {
            var individuals = await _individualRepository.LoadAllAsync();
            var result = _mapper.Map<List<IndividualAppDto>>(individuals);

            return result;
        }

        public async Task<IndividualAppDto> GetIndividualByIdAsync(string id)
        {
            var individual = await _individualRepository.LoadByIdAsync(id);
            var result = _mapper.Map<IndividualAppDto>(individual);

            return result;
        }
    }
}