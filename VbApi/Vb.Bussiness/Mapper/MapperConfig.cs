using AutoMapper;
using Vb.Data.Entity;
using Vb.Schema;

namespace Vb.Bussiness.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<CustomerRequest, Customer>();
        CreateMap<Customer, CustomerResponse>();
        
        CreateMap<AddressRequest, Address>();
        CreateMap<Address, AddressResponse>();
        
        CreateMap<ContactRequest, Contact>();
        CreateMap<Contact, ContactResponse>();
        
        CreateMap<AccountRequest, Account>();
        CreateMap<Account, AccountResponse>();
        
        CreateMap<AccountTransactionRequest, AccountTransaction>();
        CreateMap<AccountTransaction, AccountTransactionResponse>();
        
        CreateMap<EftTransactionRequest, EftTransaction>();
        CreateMap<EftTransaction, EftTransactionResponse>();
    }
}