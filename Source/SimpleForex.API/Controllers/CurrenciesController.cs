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
    public class CurrenciesController : BaseController
    {
        /// <summary>
        /// Main construcctor for the CurrencyPurchaseController.
        /// </summary>
        /// <param name="serviceProvider">API's IoC Container.</param>
        public CurrenciesController(IServiceProvider serviceProvider)
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
            CurrencyQuotationDTO currency;

            try
            {
                currency = getQuotationByCode.Execute(code);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }

            return Ok(currency);
        }

        /// <summary>
        /// Returns a quotation with the updated-on time, sell and purchase price.
        /// </summary>
        /// <param name="currencyPurchase">The currency purchase DTO.</param>
        /// <returns>A HTTPResponse with the proper status code and message base on the request provided.</returns>
        [HttpPost("{code}")]
        public IActionResult CreateCurrencyPurchase([FromRoute, FromQuery] string code, [FromBody] CurrencyPurchaseCreateDTO currencyPurchase)
        {
            var createPurchase = _commandFactory.MakeCommand<CreateCurrencyPurchaseCommand>();

            try
            {
                createPurchase.Execute((code, currencyPurchase));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
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
