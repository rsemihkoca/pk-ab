using MediatR;
using Microsoft.EntityFrameworkCore;
using Vb.Bussiness.Cqrs;
using Vb.Data;
using Vb.Data.Entity;

namespace Vb.Bussiness.Query;

public class CustomerQueryHandler :
    IRequestHandler<GetAllCustomerQuery,List<Customer>>,
    IRequestHandler<GetCustomerByIdQuery,Customer>,
    IRequestHandler<GetCustomerByParameterQuery,List<Customer>>
{
    private readonly VbDbContext dbContext;

    public CustomerQueryHandler(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Customer>().ToListAsync(cancellationToken);
    }

    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Customer>().FirstOrDefaultAsync(x=> x.CustomerNumber == request.Id ,cancellationToken);
    }

    public async Task<List<Customer>> Handle(GetCustomerByParameterQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Customer>().Where(x=> 
            x.FirstName.ToUpper().Contains(request.FirstName.ToUpper()) ||
            x.LastName.ToUpper().Contains(request.LastName.ToUpper())  || 
            x.IdentityNumber.ToUpper().Contains(request.IdentiyNumber.ToUpper())
            ).ToListAsync(cancellationToken);
    }
}