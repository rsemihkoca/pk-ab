using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Schema;
using VbApi.Filter;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransfersController : ControllerBase
{
    private readonly IMediator mediator;

    public TransfersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("Transfer")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<MoneyTransferTransactionResponse>> Transfer(
        [FromBody] MoneyTransferTransactionRequest request)
    {
        var operation = new CreateMoneyTransferTransactionCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost("EFT")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<MoneyTransferTransactionResponse>> EFT([FromBody] EftTransactionRequest request)
    {
        var operation = new CreateEftTransactionCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpGet("ByReferenceNumber")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<AccountTransactionResponse>>> GetByReferenceNumber(
        [FromQuery] string? ReferenceNumber)
    {
        var operation = new GetMoneyTransferTransactionByReferenceNumberQuery(ReferenceNumber);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("ByParameters")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<AccountTransactionResponse>>> GetByParameter(
        [FromQuery] string? ReferenceNumber,
        [FromQuery] string? Description,
        [FromQuery] int? AccountNumber,
        [FromQuery] decimal? BeginAmount,
        [FromQuery] decimal? EndAmount,
        [FromQuery] string? TransferType)
    {
        var operation = new GetMoneyTransferTransactionByParameterQuery(ReferenceNumber, Description, AccountNumber,
            BeginAmount, EndAmount, TransferType);
        var result = await mediator.Send(operation);
        return result;
    }
}