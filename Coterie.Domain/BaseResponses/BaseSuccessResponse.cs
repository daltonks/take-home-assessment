using System;

namespace Coterie.Domain.BaseResponses
{
    public abstract class BaseSuccessResponse
    {
        public bool IsSuccessful { get; } = true;
        public string TransactionId { get; }  = Guid.NewGuid().ToString();
    }
}