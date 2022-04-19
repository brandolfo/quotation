using Cotizacion.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizacion.Data
{
	public class CotizacionContext : DbContext
	{
		public CotizacionContext(DbContextOptions<CotizacionContext> options) : base(options)
		{

		}
		public DbSet<Coin> Coins { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Coin>();
		}
	}
}
