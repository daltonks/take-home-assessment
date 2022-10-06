using System.Threading.Tasks;
using Coterie.Domain.Quotes;
using Coterie.Services.Quotes;
using Microsoft.AspNetCore.Mvc;

namespace Coterie.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : CoterieBaseController
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }
        
        [HttpPost]
        public async Task<QuoteResponse> Get(QuoteRequest request)
        {
            return await _quoteService.GetAsync(request);
        }
    }
}