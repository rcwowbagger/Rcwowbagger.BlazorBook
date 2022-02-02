using System.Collections.Concurrent;

namespace Rcwowbagger.BlazorBook.Models.Orderbooks
{
    public class Orderbook
    {
        public string Symbol { get; }
        public ConcurrentDictionary<decimal, Order> Bids { get; }
        public ConcurrentDictionary<decimal, Order> Asks { get; }
        public DateTime LastUpdateUtc { get; set; }
        public Orderbook(string symbol)
        {
            Symbol = symbol;
            Bids = new ConcurrentDictionary<decimal, Order>();
            Asks = new ConcurrentDictionary<decimal, Order>();
        }
    }
}
