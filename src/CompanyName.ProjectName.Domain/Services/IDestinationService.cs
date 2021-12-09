using PrimeHolding.EventManager.Domain.Models;
using System;
using System.Threading.Tasks;

namespace PrimeHolding.EventManager.Domain.Abstractions.Services
{
    public interface IDestinationService
    {
        Task<Destination> CreateAsync(Destination model);

        Task<Destination> UpdateeAsync(Destination model);

        Task<Destination> GetByIdAsync(Guid id);

        Task<Destination> DeleteAsync(Guid id);

    }
}
