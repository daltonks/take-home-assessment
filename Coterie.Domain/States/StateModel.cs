using System;

namespace Coterie.Domain.States
{
    public class StateModel
    {
        public StateModel() { }
        
        public StateModel(string shortName, string longName, decimal priceFactor)
        {
            ShortName = shortName;
            LongName = longName;
            PriceFactor = priceFactor;
        }
        
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public decimal PriceFactor { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StateModel)obj);
        }
        
        private bool Equals(StateModel other)
        {
            return ShortName == other.ShortName && LongName == other.LongName && PriceFactor == other.PriceFactor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ShortName, LongName, PriceFactor);
        }
    }
}