using Microsoft.AspNetCore.Mvc;

namespace HSW.Controllers;
[ApiController]
[Route("api")]
public class IbanController : ControllerBase
{
    private readonly ILogger<IbanController> _logger;

    public IbanController(ILogger<IbanController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IbanResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("CreateIban")]
    public IActionResult CreateIban(IbanRequest request)
    {
        _logger.LogInformation($"Creating IBAN: (CountryCode {request.CountryCode}, BankIdentification {request.BankIdentification}, AccountNumber {request.AccountNumber})");
        try
        {
            var response = IbanResponse.OfSuccess(IbanUtil.Create(request.CountryCode, request.AccountNumber, request.BankIdentification));
            return Ok(response);
        }
        catch (ArgumentException e)
        {
            var response = IbanResponse.OfFailure("<invalid>", e.Message);
            return BadRequest(response);
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IbanResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("CreateIban")]
    public IActionResult CreateIban(string countryCode, string accountNumber, string bankIdentification)
    {
        _logger.LogInformation($"Creating IBAN: (CountryCode {countryCode}, BankIdentification {bankIdentification}, AccountNumber {accountNumber})");
        try
        {
            var response = IbanResponse.OfSuccess(IbanUtil.Create(countryCode, accountNumber, bankIdentification));
            return Ok(response);
        }
        catch (ArgumentException e)
        {
            var response = IbanResponse.OfFailure("<invalid>", e.Message);
            return BadRequest(response);
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IbanResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("ValidateIban")]
    public IActionResult ValidateIban(string iban)
    {
        _logger.LogInformation($"Validating IBAN: {iban}");
        if (IbanUtil.Validate(iban))
        {
            return Ok(IbanResponse.OfSuccess(iban));
        }
        return BadRequest(IbanResponse.OfFailure(iban, "IBAN konnte nicht geparst werden"));
    }
}