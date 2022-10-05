using System;

namespace Coterie.Domain.Businesses
{
    public class BusinessModel
    {
        public BusinessModel() { }

        public BusinessModel(string name, decimal priceFactor)
        {
            Name = name;
            PriceFactor = priceFactor;
        }
        
        public string Name { get; set; }
        public decimal PriceFactor { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BusinessModel)obj);
        }
        
        private bool Equals(BusinessModel other)
        {
            return Name == other.Name && PriceFactor == other.PriceFactor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, PriceFactor);
        }
    }
}