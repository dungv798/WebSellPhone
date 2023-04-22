namespace WebForSell.Models.ViewModels
{
    public class SmallCartViewModel
    {
        public int NumberOfItems { get; set; }
        public int TotalAmount { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
