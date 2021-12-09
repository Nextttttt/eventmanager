using AutoMapper;
using PrimeHolding.EventManager.Domain.Repositories;

namespace PrimeHolding.EventManager.Data.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly EventManagerDbContext _dbContext;

        public DestinationRepository(EventManagerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }
    }
}
