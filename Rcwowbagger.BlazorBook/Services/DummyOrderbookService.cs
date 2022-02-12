
namespace Rcwowbagger.BlazorBook.Services
{
    using Rcwowbagger.BlazorBook.Models.Orderbooks;
    using Serilog;
    public class DummyOrderbookService : IOrderbookService
    {
        private readonly ILogger _logger;
        private readonly System.Timers.Timer _timer;
        private string _symbol;

        public event OrderbookUpdateDelegate OnOrderbookUpdate;


        public DummyOrderbookService(IConfiguration configuration)
        {
            _logger = Log.ForContext<DummyOrderbookService>();
            _timer = new System.Timers.Timer()
            {
                AutoReset = true,
                Enabled = false,
                Interval = 1_000
            };

            _timer.Elapsed += _timer_Elapsed;
        }

        public void Subscribe(string symbol)
        {
            _symbol = symbol;
            _timer.Start();
        }

        public void UnSubscribe(string symbol)
        {
            _timer.Stop();
        }

        private void _timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var orderbook = OrderbookFactory.CreateRandom(_symbol);
            OnOrderbookUpdate?.Invoke(orderbook);
        }


        public Orderbook GetOrderbook(string symbol)
        {
            throw new NotImplementedException();
        }

        
    }
}
