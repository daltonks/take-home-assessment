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
    }
}