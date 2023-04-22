using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using WebForSell.Models.ViewModels;

namespace WebForSell.Models
{
    public class Product
    {
        [Key] public int ProductId { get; set; }
        [Required]
        [StringLength(50)]

        public string? ProductName { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal? ProductPrice { get; set; }
        [StringLength(500)]


        public string? ProductDescription { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [StringLength(5000)]
        public string? ProductImage { get; set; }

        public string? ProductImage2 { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [ForeignKey("BrandId")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

		[ForeignKey("isDoTW")]
		public Boolean isDoTW { get; set; }
		public Dofweek? Dofweek { get; set; }

		[ForeignKey("isLasted")]
		public Boolean isLasted { get; set; }
		public LastestProduct? LastestProduct { get; set; }

		[ForeignKey("isArr")]
		public Boolean isArr { get; set; }
		public NewArr? NewArr { get; set; }

		[ForeignKey("isOnSale")]
		public Boolean isOnSale { get; set; }
		public OnSale? OnSale { get; set; }

		[ForeignKey("isTop")]
		public Boolean isTop { get; set; }
		public TopSell? TopSell { get; set; }
        

    }
}



