using System;

namespace Coterie.Domain.BaseResponses
{
    public class BaseExceptionResponse
    {
        public bool IsSuccessful { get; } = false;
        public string TransactionId { get; }  = Guid.NewGuid().ToString();
        public string Message { get; set; }
    }
}