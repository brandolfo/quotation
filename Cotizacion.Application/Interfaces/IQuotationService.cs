﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizacion.Application.Interfaces
{
	public interface IQuotationService
	{
		Task AddQuotation(int number);
	}
}
