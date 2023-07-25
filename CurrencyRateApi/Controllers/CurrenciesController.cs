using Microsoft.AspNetCore.Mvc;
using CurrencyRateApi.Models.Currency;
using CurrencyRateApi.Services;

namespace CurrencyRateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private ICurrencyService _currencyService;

        public CurrenciesController(ICurrencyService userService)
        {
            _currencyService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _currencyService.GetAll();
            return Ok(users);
        }

        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {
            var user = _currencyService.GetByCode(code);
            return Ok(user);
        }

        [HttpGet, Route("/prices")]
        public IActionResult GetPriceChanges([FromQuery] GetPricesRequest model)
        {
            var result = _currencyService.GetPriceChanges(model);
            return Ok(result);
        }
    }
}
