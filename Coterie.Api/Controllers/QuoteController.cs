using System.Threading.Tasks;
using Coterie.Domain.Quotes;
using Coterie.Services.Quotes;
using Microsoft.AspNetCore.Http;
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
            var response = await _quoteService.GetAsync(request);
            if (!response.IsSuccessful)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            return response;
        }
    }
}