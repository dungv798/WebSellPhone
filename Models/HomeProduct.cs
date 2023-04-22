 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebForSell.Models
{
    public class HomeProduct
    {
        [Key] 
        public int HomeProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string? HomeProductName { get; set; }
        [ForeignKey("NewArrId")]

        public int NewArrId { get; set; }
        public NewArr? NewArr { get; set; }


        [ForeignKey("TopSellId")]
        public int TopSellId { get; set; }
        public TopSell? TopSell { get; set; }


        [ForeignKey("OnSaleId")]
        public int OnSaleId { get; set; }
        public OnSale? OnSale { get; set; }
        [ForeignKey("LastestProductId")]
        public int LastestProductId { get; set; }
        public LastestProduct? LastestProduct { get; set; }
        [ForeignKey("DofweekId")]
        public int DofweekId { get; set; }
        public Dofweek? Dofweek { get; set; }

    }
}
