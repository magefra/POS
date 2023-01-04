using POS.Domain.Entities;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Infrastructure.Contexts;

namespace POS.Infraestructure.Persistences.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly POSContext _context;

        public CategoryRepository(POSContext context)
        {
            _context = context;
        }
    }
}
