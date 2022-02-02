using Rcwowbagger.BlazorBook.Models.Orderbooks;

namespace Rcwowbagger.BlazorBook.Data
{
    public class OrderbookView
    {
        public Order BestBid { get; set; }
        public Order BestAsk { get; set; }
        public static OrderbookView CreateFrom(Orderbook orderbook)
        {
            return new OrderbookView
            {
                BestBid = orderbook.Bids.OrderByDescending(x => x.Key).Select(x => x.Value).FirstOrDefault(),
                BestAsk = orderbook.Asks.OrderBy(x => x.Key).Select(x => x.Value).FirstOrDefault()
            };
        }
    }
}
