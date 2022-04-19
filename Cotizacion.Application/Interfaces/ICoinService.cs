using Cotizacion.Application.DTO;
using System;
using System.Threading.Tasks;

namespace Cotizacion.Application.Interfaces
{
	public interface ICoinService
	{
		Task FirstLoad();
		Task<float> GetExchangeRate(string currencyFrom, string currencyTo, int fee, float amount);
		Task<float> HowMuchItIs(string coinFrom, string coinTo, float amount, int fee);

	}
}
