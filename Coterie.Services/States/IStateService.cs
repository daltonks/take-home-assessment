using System.Threading.Tasks;
using Coterie.Domain.States;

namespace Coterie.Services.States
{
    public interface IStateService
    {
        Task<State> GetAsync(string shortOrLongName);
    }
}