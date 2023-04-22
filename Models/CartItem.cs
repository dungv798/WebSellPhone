using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebForSell.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Price { get; set; }
        public decimal?  Total 
        { 
            get { return Quantity * Price; }
        }
        public string Image { get; set; }
        public CartItem()
        {

        }
        public CartItem(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Price = product.ProductPrice;
            Quantity = 1;
            Image = product.ProductImage;
        }
        public ICollection<Product>? Products { get; set; }
    }
}
