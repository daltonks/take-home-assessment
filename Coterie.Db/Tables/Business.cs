using Coterie.Domain.Businesses;

namespace Coterie.Db.Tables
{
    public class Business
    {
        public Business() { }
        
        public Business(string name, decimal priceFactor)
        {
            Name = name;
            PriceFactor = priceFactor;
        }
        
        public string Name { get; set; }
        public decimal PriceFactor { get; set; }

        public BusinessModel ToModel()
        {
            return new BusinessModel(Name, PriceFactor);
        }
    }
}