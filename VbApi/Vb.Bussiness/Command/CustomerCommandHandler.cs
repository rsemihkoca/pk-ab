using MediatR;
using Microsoft.EntityFrameworkCore;
using Vb.Bussiness.Cqrs;
using Vb.Data;
using Vb.Data.Entity;

namespace Vb.Bussiness.Command;

public class CustomerCommandHandler :
    IRequestHandler<CreateCustomerCommand, Customer>,
    IRequestHandler<UpdateCustomerCommand>,
    IRequestHandler<DeleteCustomerCommand>

{
    private readonly VbDbContext dbContext;

    public CustomerCommandHandler(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.AddAsync(request.Model, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return entity.Entity;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var fromdb = await dbContext.Set<Customer>().Where(x => x.CustomerNumber == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        fromdb.FirstName = request.Model.FirstName;
        fromdb.LastName = request.Model.LastName;
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var fromdb = await dbContext.Set<Customer>().Where(x => x.CustomerNumber == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        //dbContext.Set<Customer>().Remove(fromdb);
        fromdb.IsActive = false;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}