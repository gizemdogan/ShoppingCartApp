namespace ShoppingCartProject.Interfaces
{
    public interface ICartLine
    {
        IProduct Product { get; set; }
        int Quantity { get; set; }
    }
}
