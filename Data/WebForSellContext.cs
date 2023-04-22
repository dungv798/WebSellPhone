using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebForSell.Models;

namespace WebForSell.Data
{
    public class WebForSellContext : DbContext
    {
        public WebForSellContext (DbContextOptions<WebForSellContext> options)
            : base(options)
        {
        }

        public DbSet<WebForSell.Models.User> User { get; set; } = default!;

        public DbSet<WebForSell.Models.Category>? Category { get; set; }

        public DbSet<WebForSell.Models.Product>? Product { get; set; }

        public DbSet<WebForSell.Models.Brand>? Brand { get; set; }

        public DbSet<WebForSell.Models.Dofweek>? Dofweek { get; set; }

        public DbSet<WebForSell.Models.LastestProduct>? LastestProduct { get; set; }

        public DbSet<WebForSell.Models.NewArr>? NewArr { get; set; }

        public DbSet<WebForSell.Models.OnSale>? OnSale { get; set; }

        public DbSet<WebForSell.Models.TopSell>? TopSell { get; set; }

        public DbSet<WebForSell.Models.HomeProduct>? HomeProduct { get; set; }
    }
}
