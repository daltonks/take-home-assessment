using Coterie.Domain.States;

namespace Coterie.Db.Tables
{
    public class StateRow
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public decimal PriceFactor { get; set; }

        public State ToModel()
        {
            return new State(ShortName, LongName, PriceFactor);
        }
    }
}