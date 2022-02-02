using Microsoft.AspNetCore.Components;
using Rcwowbagger.BlazorBook.Services;

namespace Rcwowbagger.BlazorBook.Pages
{
    using Radzen.Blazor;
    using Rcwowbagger.BlazorBook.Data;
    using Rcwowbagger.BlazorBook.Models.Orderbooks;
    using Serilog;
    public class ShowOrderbookBase : ComponentBase
    {
        [Inject] public IOrderbookService OrderbookService { get; set; }
        [Parameter] public string Symbol { get; set; }
        public IEnumerable<OrderbookView> TopOfBook { get; private set;  }
        public RadzenDataGrid<OrderbookView> grid { get; set; }

        private ILogger _logger;

      
        protected override async Task OnInitializedAsync()
        {
            _logger = Log.ForContext<ShowOrderbookBase>();
            OrderbookService.OnOrderbookUpdate += OnOrderbookUpdate;
            OrderbookService.Subscribe(Symbol);
        }

        private void OnOrderbookUpdate(Orderbook orderbook)
        {
            _logger.Information("Got Update");
            TopOfBook = new List<OrderbookView> { OrderbookView.CreateFrom(orderbook) };
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
    }
}
