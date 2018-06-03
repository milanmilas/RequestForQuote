using System.ComponentModel;
using System.Runtime.CompilerServices;
using RfqUi.Annotations;

namespace RfqUi.Models
{
    public class Trade : BaseModel
    {
        public Trade(string tradeId)
        {
            TradeId = tradeId;
        }

        public string TradeId { get; }

        public string Isin { get; }

        public double Size { get; }

        public Side Side { get; }
    }
}