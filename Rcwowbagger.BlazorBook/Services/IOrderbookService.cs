namespace Rcwowbagger.BlazorBook.Services
{
    using Rcwowbagger.BlazorBook.Models.Orderbooks;

    public delegate void OrderbookUpdateDelegate(Orderbook orderbook);

    public interface IOrderbookService
    {
        Orderbook GetOrderbook(string symbol);
        void Subscribe(string symbol);
        void UnSubscribe(string symbol);

        event OrderbookUpdateDelegate OnOrderbookUpdate;
    }
}
