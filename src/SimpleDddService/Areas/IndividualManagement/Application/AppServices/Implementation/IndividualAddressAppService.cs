using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SimpleDddService.Areas.IndividualManagement.Application.Dtos;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;
using SimpleDddService.Infrastructure.DataAccess.Repositories;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppServices.Implementation
{
    public class IndividualAddressAppService : IIndividualAddressAppService
    {
        private readonly IMapper _mapper;
        private IRepository<Individual> _individualRepository;

        public IndividualAddressAppService(IRepositoryFactory repositoryFactory, IMapper mapper)
        {
            _mapper = mapper;
            _individualRepository = repositoryFactory.CreateRepository<Individual>();
        }

        public async Task<AddressDto> AddOrUpdateAddressAsync(string individualId, AddressDto dto)
        {
            var address = _mapper.Map<Address>(dto);
            var individual = await _individualRepository.LoadByIdAsync(individualId);

            individual.AddOrUpdateAddress(address);

            var returnedIndividual = await _individualRepository.SaveAsync(individual);

            var returnedAddress = returnedIndividual.Addresses.First(f => f.Id == address.Id);
            var result = _mapper.Map<AddressDto>(returnedAddress);

            return result;
        }

        public async Task<IReadOnlyCollection<AddressDto>> GetAllAddressesAsync(string individualId)
        {
            var individual = await _individualRepository.LoadByIdAsync(individualId);
            var result = _mapper.Map<List<AddressDto>>(individual.Addresses);
            return result;
        }
    }
}