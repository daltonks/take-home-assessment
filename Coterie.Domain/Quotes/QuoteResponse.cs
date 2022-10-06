using System;
using System.Collections.Generic;

namespace Coterie.Domain.Quotes
{
    public class QuoteResponse
    {
        public string Business { get; set; }
        public decimal Revenue { get; set; }
        public List<PremiumModel> Premiums { get; set; } = new();
        public bool IsSuccessful { get; set; }
        public string TransactionId { get; } = Guid.NewGuid().ToString();
        public string Message { get; set; }
    }
}