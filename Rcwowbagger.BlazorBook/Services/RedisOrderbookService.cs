
namespace Rcwowbagger.BlazorBook.Services
{
    using Rcwowbagger.BlazorBook.Models.Orderbooks;
    using Serilog;

    public class RedisOrderbookService : IOrderbookService
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;
        public RedisOrderbookService(IConfiguration configuration)
        {
            _logger = Log.ForContext<RedisOrderbookService>();
            _connectionString = configuration.GetSection("Redis").GetValue<string>("ConnectionString");
        }

        public event OrderbookUpdateDelegate OnOrderbookUpdate;


        public Orderbook GetOrderbook(string symbol)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(string symbol)
        {
            throw new NotImplementedException();
        }

        public void UnSubscribe(string symbol)
        {
            throw new NotImplementedException();
        }
    }
}
