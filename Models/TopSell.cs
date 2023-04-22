using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebForSell.Models
{
    public class TopSell
    {
        [Key]
        public int TopSellId { get; set; }
        [Required]
		public Boolean? isTop { get; set; }
		[Required]

        [StringLength(50)]

        public string? TopSellName { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal? TopSellPrice { get; set; }
        [StringLength(500)]
        public string? TopSellImage { get; set; }
        public ICollection<HomeProduct>? HomeProducts { get; set; }
		public ICollection<Product>? Products { get; set; }
	}
}
