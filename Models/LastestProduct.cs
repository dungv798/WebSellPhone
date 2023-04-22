using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebForSell.Models
{
    public class LastestProduct
    {
        [Key] 
        public int LastestProductId { get; set; }
        [Required]
       

		public Boolean? isLasted { get; set; }
		[Required]
        [StringLength(50)]
        public string? LastestProductName { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal? LastestProductPrice { get; set; }
        [StringLength(500)]
        public string? LastestProductImage { get; set; }
        public ICollection<HomeProduct>? HomeProducts { get; set; }
		public ICollection<Product>? Products { get; set; }
	}
}
