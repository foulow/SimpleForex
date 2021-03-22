using System;
using Microsoft.AspNetCore.Mvc;
using SimpleForex.Application.Commands;
using SimpleForex.Application.DTOs;
using SimpleForex.Application.Queries;

namespace SimpleForex.API.Controllers
{
    /// <summary>
    /// Controller to make purchases for the currencies supported by the API.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyPurchasesController : BaseController
    {
        /// <summary>
        /// Main construcctor for the CurrencyPurchaseController.
        /// </summary>
        /// <param name="serviceProvider">API's IoC Container.</param>
        public CurrencyPurchasesController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        /// <summary>
        /// Returns a quotation with the updated-on time, sell and purchase price.
        /// </summary>
        /// <param name="code">The currency's code been consult for a quotation.</param>
        /// <returns>A HTTPResponse with the proper status code and message base on the request provided.</returns>
        [HttpGet("{code}")]
        public IActionResult GetCurrencyQuoutationByCode([FromRoute, FromQuery] string code)
        {
            var getQuotationByCode = _queryFactory.MakeQuery<GetCurrencyQuotationByCode>();

            var currency = getQuotationByCode.Execute(code);

            return Ok(currency);
        }

        /// <summary>
        /// Returns a quotation with the updated-on time, sell and purchase price.
        /// </summary>
        /// <param name="currencyPurchase">The currency purchase DTO.</param>
        /// <returns>A HTTPResponse with the proper status code and message base on the request provided.</returns>
        [HttpPost]
        public IActionResult CreateCurrencyPurchase([FromBody] CurrencyPurchaseDTO currencyPurchase)
        {
            var createPurchase = _commandFactory.MakeCommand<CreateCurrencyPurchaseCommand>();

            try
            {
                createPurchase.Execute(currencyPurchase);
            }
            catch (MethodAccessException ex)
            {
                return Unauthorized(new
                {
                    Error = ex.Message
                });
            }

            return Ok();
        }
    }
}
