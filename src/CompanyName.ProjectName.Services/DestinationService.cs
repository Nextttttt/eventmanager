using PrimeHolding.EventManager.Domain.Abstractions.Services;
using PrimeHolding.EventManager.Domain.Models;
using PrimeHolding.EventManager.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace PrimeHolding.EventManager.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;

        public DestinationService(IDestinationRepository destinationRepository)
            
        {
            _destinationRepository = destinationRepository;
        }

        public async Task<Destination> CreateAsync(Destination model)
        {
            return await _destinationRepository.CreateAsync(model);
        }

        public async Task<Destination> UpdateAsync(Destination model)
        {
            return await _destinationRepository.UpdateAsync(model);
        }

        public async Task<Destination> GetByIdAsync(Guid id)
        {
            return await _destinationRepository.GetByIdAsync(id);
        }

        public async Task<Destination> DeleteAsync(Guid id)
        {
            return await _destinationRepository.DeleteAsync(id);
        }
    }
}
