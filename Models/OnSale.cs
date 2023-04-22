using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebForSell.Models
{
    public class OnSale
    {
        [Key] 
        public int OnSaleId { get; set; }
        [Required]
       
		public Boolean? isOnSale { get; set; }
		[Required]
        [StringLength(50)]
        public string? OnSaleName { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal? OnSalePrice { get; set; }
        [StringLength(500)]
        public string? OnSaleImage { get; set; }
        public ICollection<HomeProduct>? HomeProducts { get; set; }
		public ICollection<Product>? Products { get; set; }
	}
}
