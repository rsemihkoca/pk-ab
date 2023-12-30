using MediatR;
using Vb.Data.Entity;

namespace Vb.Bussiness.Cqrs;


public record CreateCustomerCommand(Customer Model) : IRequest<Customer>;
public record UpdateCustomerCommand(int Id,Customer Model) : IRequest;
public record DeleteCustomerCommand(int Id) : IRequest;

public record GetAllCustomerQuery() : IRequest<List<Customer>>;
public record GetCustomerByIdQuery(int Id) : IRequest<Customer>;
public record GetCustomerByParameterQuery(string FirstName,string LastName,string IdentiyNumber) : IRequest<List<Customer>>;