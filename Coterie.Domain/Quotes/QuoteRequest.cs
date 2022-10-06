using System;

namespace Coterie.Domain.Quotes
{
    public class QuoteRequest
    {
        public string Business { get; set; }
        public decimal Revenue { get; set; }
        public string[] States { get; set; } = Array.Empty<string>();
    }
}