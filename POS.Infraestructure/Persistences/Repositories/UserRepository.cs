using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Infrastructure.Contexts;

namespace POS.Infraestructure.Persistences.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly POSContext _contex;

        public UserRepository(POSContext context) : base(context)
        {
            _contex = context;
        }


        public async Task<User> AccountByUserName(string userName)
        {
            var acount = await _contex.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName!.Equals(userName));
            return acount!;
        }
    }
}
