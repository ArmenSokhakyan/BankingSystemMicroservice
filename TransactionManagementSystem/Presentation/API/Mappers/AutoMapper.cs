using AutoMapper;
using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Presentation.API.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<InTransaction, InTransactionDTO>().ReverseMap();
            CreateMap<OutTransaction, OutTransactionDTO>().ReverseMap();
            CreateMap<TransferTransaction, TransferTransactionDTO>().ReverseMap();
        }
    }
}
