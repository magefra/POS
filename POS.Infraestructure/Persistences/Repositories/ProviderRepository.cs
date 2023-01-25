using POS.Domain.Entities;
using POS.Infraestructure.Commons.Bases.Request;
using POS.Infraestructure.Commons.Bases.Response;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Infrastructure.Contexts;

namespace POS.Infraestructure.Persistences.Repositories
{
    public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(POSContext context) : base(context)
        {
        }

        public async Task<BaseEntityResponse<Provider>> ListProviders(BaseFilterRequest filters)
        {
            throw new NotImplementedException();
        }
    }
}
