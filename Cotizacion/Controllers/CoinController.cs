﻿using Cotizacion.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cotizacion.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoinController : ControllerBase
	{
		

		private readonly ICoinService _coinService;
		public CoinController(ICoinService coinService)
		{
			_coinService = coinService;
		}

		/// <summary>
		/// carga inicial de los exchange rate en la db.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> FirstCoinLoad()
		{
			await _coinService.FirstLoad();
			return new OkObjectResult(true);
		}

		/// <summary>
		/// calcula la cantidad de dinero que recibe una persona al enviar un monto en moneda local a otro tipo de moneda
		/// </summary>
		/// <param name="coinFrom"> moneda de quien envia</param>
		/// <param name="coinTo"> moneda de quien recibe</param>
		/// <param name="amount">monto de quien envia</param>
		/// <param name="fee">recargo</param>
		/// <returns>flotante que representa el monto que recibira el destinatario.</returns>
		[HttpGet("MoneyToSend")]
		public async Task<IActionResult> MoneyToSend(string coinFrom, string coinTo, float amount, int fee)
		{
			var result = await _coinService.GetExchangeRate(coinFrom, coinTo, fee, amount);
			return new OkObjectResult(result);
		}

		/// <summary>
		/// determina la cantidad de dinero que una persona debe enviar en moneda local para que otra otra persona lo reciba en otro tipo de moneda.
		/// </summary>
		/// <param name="coinFrom">moneda de quien envia</param>
		/// <param name="coinTo">moneda de quien recibe</param>
		/// <param name="amount">monto de quien recibe</param>
		/// <param name="fee">recargo</param>
		/// <returns>un flotante que representa cuanto dinero se debe de depositar</returns>
		[HttpGet("HowMuchSend")]
		public async Task<IActionResult> HowMuchItIs(string coinFrom, string coinTo, float amount, int fee)
		{
			var result = await _coinService.HowMuchItIs( coinFrom, coinTo, amount, fee);
			return new OkObjectResult(result);
		}
	}
}
