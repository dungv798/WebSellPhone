using System.ComponentModel.DataAnnotations;

namespace WebForSell.Models.ViewModels
{
    public class CartViewModel
    {
        [Key]
        public List<CartItem>? CartItems { get; set; }
        public decimal GrandToTal { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
