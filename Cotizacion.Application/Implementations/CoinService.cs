using Cotizacion.Application.DTO;
using Cotizacion.Application.Interfaces;
using Cotizacion.Data;
using Cotizacion.Data.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cotizacion.Application.Implementations
{
	public class CoinService : ICoinService
	{
		private readonly CotizacionContext _context;
		public CoinService(CotizacionContext context)
		{
			_context = context;
		}
		public async Task FirstLoad()
		{
			var client = new HttpClient();
			var baseUrl = "http://api.currencylayer.com/live?access_key=";
			var accessKey = "0efb306d8edf7361c17548430057d46e";
			HttpResponseMessage response = await client.GetAsync($"{baseUrl}{accessKey}");
			var content = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<quotes>(content);

			var coinList = new List<Coin>();

			foreach (var coin in result.Quotes)
			{
				var addCoin = new Coin()
				{
					Code = coin.Key.Substring(coin.Key.Length - 3),
					QuotationinUSD = coin.Value
				};
				coinList.Add(addCoin);
			}
			await _context.Coins.AddRangeAsync(coinList);
			await _context.SaveChangesAsync();
		}

		public async Task<float> GetExchangeRate(string currencyFrom, string currencyTo, int fee, float amount = 1)
		{
			if (currencyFrom == null || currencyTo == null)
				return 0;

			// First Get the exchange rate of both currencies in dolar
			float currencyFromRate = await GetCurrencyRateInDolar(currencyFrom);
			float currencyToRate = await GetCurrencyRateInDolar(currencyTo);

			return ((amount * currencyToRate) / currencyFromRate) * (100 - fee) / 100;
		}

		public async Task<float> HowMuchItIs(string coinFrom, string coinTo, float amount, int fee)
		{
			if (coinFrom == null || coinTo == null)
				return 0;

			// First Get the exchange rate of both currencies in dolar
			float currencyFromRate = await GetCurrencyRateInDolar(coinFrom);
			float currencyToRate = await GetCurrencyRateInDolar(coinTo);

			return ((amount * currencyFromRate) / currencyToRate) * (100 + fee) / 100;
		}

		private async Task<float> GetCurrencyRateInDolar(string currencyFrom)
		{
			var exrate = await _context.Coins.FirstOrDefaultAsync(x => x.Code == currencyFrom);
			return exrate.QuotationinUSD;
		}
	}
}
