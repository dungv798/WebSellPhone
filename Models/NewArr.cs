using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebForSell.Models
{
    public class NewArr
    {
        [Key] 
        public int NewArrId { get; set; }
        [Required]
       

		public Boolean? isArr { get; set; }
		[Required]
        [StringLength(50)]
        public string? NewArrName { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal? NewArrPrice { get; set; }
        [StringLength(500)]
        public string? NewArrImage { get; set; }
        public ICollection<HomeProduct>? HomeProducts { get; set; }
		public ICollection<Product>? Products { get; set; }
	}
}
