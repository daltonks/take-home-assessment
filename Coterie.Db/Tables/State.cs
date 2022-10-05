using Coterie.Domain.States;

namespace Coterie.Db.Tables
{
    public class State
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public decimal PriceFactor { get; set; }

        public StateModel ToModel()
        {
            return new StateModel(ShortName, LongName, PriceFactor);
        }
    }
}