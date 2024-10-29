namespace Rcwowbagger.BlazorBook.Models;

public class Order
{
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public Side Side { get; set; }

    public override string ToString() => $"{Side} {Price} {Quantity}";
}
