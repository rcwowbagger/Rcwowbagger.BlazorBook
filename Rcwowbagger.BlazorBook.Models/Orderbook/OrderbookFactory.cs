namespace Rcwowbagger.BlazorBook.Models.Orderbooks
{
    public static class OrderbookFactory
    {
        private static readonly Random _random = new Random();
        public static Orderbook CreateRandom(string symbol)
        {
            var orderbook = new Orderbook(symbol);

            Enumerable.Range(0, 10).ToList().ForEach(x =>
            {
                var bid = GenerateOrder(orderbook.Symbol, Side.Bid, 10);
                orderbook.Bids.TryAdd(bid.Price,bid);
                var ask = GenerateOrder(orderbook.Symbol, Side.Ask, 10);
                orderbook.Asks.TryAdd(ask.Price, ask);

            });
            return orderbook;
        }


        public static Order GenerateOrder(string symbol, Side side, double reference = 0)
        {
            var order = new Order()
            {
                Side = side,
                Price = Convert.ToDecimal( side == Side.Bid ? reference - _random.NextDouble() : _random.NextDouble() + reference),
                Quantity = 1,
                Symbol = symbol
            };

            return order;
        }
    }
}
