using System.Linq;
using System.Threading.Tasks;
using Coterie.Db;
using Coterie.Domain.Businesses;
using Microsoft.EntityFrameworkCore;

namespace Coterie.Services.Businesses
{
    public class BusinessService : IBusinessService
    {
        private readonly CoterieDbContext _dbContext;

        public BusinessService(CoterieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BusinessModel> GetAsync(string name)
        {
            return await _dbContext.Businesses.Where(
                e => e.Name == name
            )
            .Select(e => e.ToModel())
            .FirstOrDefaultAsync();
        }
    }
}