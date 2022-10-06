using System;

namespace Coterie.Domain.Quotes
{
    public class PremiumModel
    {
        public decimal Premium { get; set; }
        public string State { get; set; }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PremiumModel)obj);
        }
        
        private bool Equals(PremiumModel other)
        {
            return Premium == other.Premium && State == other.State;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Premium, State);
        }
    }
}