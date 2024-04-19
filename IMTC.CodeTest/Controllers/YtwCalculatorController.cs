using IMTC.CodeTest.Domain.Dtos;
using IMTC.CodeTest.Domain.Enums;
using IMTC.CodeTest.Domain.Interfaces.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

namespace IMTC.CodeTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YtwCalculatorController : ControllerBase
    {
        private readonly ILogger<YtwCalculatorController> _logger;
        private readonly IYtwCalculatorService _ytwCalculatorService;

        public YtwCalculatorController(ILogger<YtwCalculatorController> logger, IYtwCalculatorService ytwCalculatorService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _ytwCalculatorService = ytwCalculatorService ?? throw new ArgumentNullException(nameof(ytwCalculatorService));
        }

        [HttpGet("{couponType}/{bondType}")]
        public async Task<ActionResult<decimal>> Get(CouponType couponType, BondType bondType)
        {
            _logger.LogInformation("YtwCalculator start calculate");

            var bond = new Bond(couponType, bondType);
            var response = await _ytwCalculatorService.CalculateYtwForBond(bond);

            _logger.LogInformation($"YtwCalculator end calculate with response {response}");

            return response is null
                ? NotFound("Error to calculate")
                : Ok(response);
        }
    }
}
