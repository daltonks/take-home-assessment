using System.Threading.Tasks;
using Coterie.Domain.Businesses;

namespace Coterie.Services.Businesses
{
    public interface IBusinessService
    {
        Task<BusinessModel> GetAsync(string name);
    }
}