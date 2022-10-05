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
    }
}