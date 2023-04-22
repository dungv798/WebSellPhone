using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebForSell.Models
{
    public class Dofweek
    {
        [Key] 
        public int DofweekId { get; set; }
        [Required]
        
		public Boolean? isDoTW { get; set; }
		[Required]
        [StringLength(50)]
        public string? DofweekName { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal? DofweekPrice { get; set; }
        [StringLength(500)]


        public string? DofweekDescription { get; set; }
        [Required]
      
        public string? DofweekImage { get; set; }
        public ICollection<HomeProduct>? HomeProducts { get; set; }
		public ICollection<Product>? Products { get; set; }
	}
}
