using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Bussiness.Cqrs;
using Vb.Data.Entity;
using Vb.Schema;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    public CustomersController(IMediator mediator,IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<List<Customer>> Get()
    {
        var operation = new GetAllCustomerQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<Customer> Get(int id)
    {
        var operation = new GetCustomerByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<CustomerResponse> Post([FromBody] CustomerRequest customer)
    {
        var customerEntity = mapper.Map<CustomerRequest, Customer>(customer);
        var operation = new CreateCustomerCommand(customerEntity);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] CustomerRequest customer)
    {
        customer.CustomerNumber = id;
        var operation = new UpdateCustomerCommand(id,customer);
        await mediator.Send(operation);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var operation = new DeleteCustomerCommand(id);
        await mediator.Send(operation);
    }
}