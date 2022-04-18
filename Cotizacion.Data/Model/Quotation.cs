using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizacion.Data.Model
{
	public class Quotation
	{
		public Guid QuotationId { get; set; }
		public float Buy { get; set; }
	}
}
