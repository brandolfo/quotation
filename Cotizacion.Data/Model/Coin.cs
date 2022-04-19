using System;

namespace Cotizacion.Data.Model
{
	public class Coin
	{
		public Guid CoinId { get; set; }
		public string Code { get; set; }
		public float QuotationinUSD { get; set; }
	}
}
