using System.Linq;
using System.Threading.Tasks;
using Coterie.Db;
using Coterie.Domain.States;
using Microsoft.EntityFrameworkCore;

namespace Coterie.Services.States
{
    public class StateService : IStateService
    {
        private readonly CoterieDbContext _dbContext;

        public StateService(CoterieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StateModel> GetAsync(string shortOrLongName)
        {
            return await _dbContext.States.Where(
                e => e.ShortName == shortOrLongName || e.LongName == shortOrLongName
            )
            .Select(e => e.ToModel())
            .FirstOrDefaultAsync();
        }
    }
}