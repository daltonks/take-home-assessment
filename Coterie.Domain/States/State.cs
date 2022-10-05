namespace Coterie.Domain.States
{
    public class State
    {
        public State(string shortName, string longName, decimal priceFactor)
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