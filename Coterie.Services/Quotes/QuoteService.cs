using System.Threading.Tasks;
using Coterie.Domain.Businesses;
using Coterie.Domain.Quotes;
using Coterie.Domain.States;
using Coterie.Services.Businesses;
using Coterie.Services.States;

namespace Coterie.Services.Quotes
{
    public class QuoteService : IQuoteService
    {
        private readonly IBusinessService _businessService;
        private readonly IStateService _stateService;

        public QuoteService(IBusinessService businessService, IStateService stateService)
        {
            _businessService = businessService;
            _stateService = stateService;
        }

        public async Task<QuoteResponse> GetAsync(QuoteRequest request)
        {
            var result = new QuoteResponse
            {
                Business = request.Business,
                Revenue = request.Revenue,
                IsSuccessful = false
            };

            if (request.Revenue <= 0)
            {
                result.Message = $"Revenue is invalid: {request.Revenue}";
                return result;
            }
            
            var business = await _businessService.GetAsync(request.Business);
            if (business == null)
            {
                result.Message = $"Business is invalid: {request.Business}";
                return result;
            }

            foreach (var stateName in request.States)
            {
                var state = await _stateService.GetAsync(stateName);
                if (state == null)
                {
                    result.Message = $"State is invalid: {stateName}";
                    result.Premiums.Clear();
                    return result;
                }

                var premium = GetPremium(request.Revenue, business, state);
                result.Premiums.Add(premium);
            }

            result.IsSuccessful = true;
            return result;
        }

        private static PremiumModel GetPremium(decimal revenue, BusinessModel business, StateModel state)
        {
            var basePremium = revenue / 1000; // TODO: Clarify this value and where it comes from
            const int hazardFactor = 4;       // TODO: Clarify this value and where it comes from
            
            return new PremiumModel
            {
                State = state.ShortName,
                Premium = state.PriceFactor * business.PriceFactor * basePremium * hazardFactor
            };
        }
    }
}