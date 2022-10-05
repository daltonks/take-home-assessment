namespace Coterie.Domain.States
{
    public class StateModel
    {
        public StateModel(string shortName, string longName, decimal priceFactor)
        {
            ShortName = shortName;
            LongName = longName;
            PriceFactor = priceFactor;
        }
        
        public string ShortName { get; }
        public string LongName { get; }
        public decimal PriceFactor { get; }
    }
}