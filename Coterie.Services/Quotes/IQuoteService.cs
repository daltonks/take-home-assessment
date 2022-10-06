using System.Threading.Tasks;
using Coterie.Domain.Quotes;

namespace Coterie.Services.Quotes
{
    public interface IQuoteService
    {
        Task<QuoteResponse> GetAsync(QuoteRequest request);
    }
}