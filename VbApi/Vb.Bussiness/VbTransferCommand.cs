using MediatR;
using Vb.Data.Entity;

namespace Vb.Bussiness;

public record VbTransferCommand : IRequest<Customer>;