using Microsoft.AspNetCore.Mvc;

namespace HSW.Controllers;
[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    private readonly ApplicationDbContext _context;

    public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    [Route("customer")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCustomer(CustomerRequest request)
    {
        if (request.Iban is null && request.IbanRequest is null)
        {
            return BadRequest();
        }

        try
        {
            if (request.Iban is not null)
            {
                var ibanResponse = await IbanClient.ProcessValidation(request.Iban);
                var valid = ibanResponse is not null && ibanResponse.Valid;
                if (!valid)
                {
                    return BadRequest();
                }
            }

            if (request.IbanRequest is not null)
            {
                var ibanResponse = await IbanClient.ProcessCreation(request.IbanRequest);
                var valid = ibanResponse is not null && ibanResponse.Valid;
                if (!valid)
                {
                    return BadRequest();
                }
                request.Iban = ibanResponse?.Iban;
            }
        }
        catch (Exception)
        {
            return BadRequest();
        }

        var customer = new Customer(request.Name, request.Address, request.Iban!);
        _context.Customers.Add(customer);
        _context.SaveChanges();


        var response = new CustomerResponse(customer.Id, customer.Name, customer.Address, customer.Iban);

        return CreatedAtAction(nameof(GetCustomer), new { id = response.Id }, response);
    }

    [HttpPost]
    [Route("customer2")]
    public async Task<IActionResult> CreateCustomer2(CustomerRequest request)
    {
        if (request.Iban is null && request.IbanRequest is null)
        {
            return BadRequest();
        }

        try
        {
            if (request.Iban is not null)
            {
                var ibanResponse = await IbanClient.ProcessValidation(request.Iban);
                var valid = ibanResponse is not null && ibanResponse.Valid;
                if (!valid)
                {
                    return BadRequest();
                }
            }

            if (request.IbanRequest is not null)
            {
                var ibanResponse = await IbanClient.ProcessCreation(request.IbanRequest);
                var valid = ibanResponse is not null && ibanResponse.Valid;
                if (!valid)
                {
                    return BadRequest();
                }
                request.Iban = ibanResponse?.Iban;
            }
        }
        catch (Exception)
        {
            return BadRequest();
        }

        Customer customer = new Customer(request.Name, request.Address, request.Iban!);
        _context.Customers.Add(customer);
        _context.SaveChanges();

        CustomerResponse response = new CustomerResponse(customer.Id, customer.Name, customer.Address, customer.Iban);

        return Ok(response);
    }

    [HttpGet]
    [Route("customer/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetCustomer(long id)
    {

        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customer is null)
        {
            return NotFound();
        }

        var response = new CustomerResponse(customer.Id, customer.Name, customer.Address, customer.Iban);

        return Ok(response);

    }

    [HttpGet]
    [Route("customers")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerResponse>))]
    public IActionResult GetCustomers()
    {
        var response = new List<CustomerResponse>();
        _context.Customers.ToList().ForEach(c => response.Add(new CustomerResponse(c.Id, c.Name, c.Address, c.Iban)));
        return Ok(response);

    }
}