namespace Rcwowbagger.BlazorBook.Models.Orderbooks
{
    public class Order
    {
        public string Symbol { get; set; }
        public Decimal Price { get; set; }
        public Decimal Quantity { get; set; }
        public Side Side { get; set; }

        public override string ToString() => $"{Symbol} {Side} {Price} {Quantity}";
    }
}
