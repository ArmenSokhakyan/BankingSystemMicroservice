using AutoMapper;
using ReferanceManagementSystem.Core.Entities;
using ReferanceManagementSystem.Presentation.API.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReferanceManagementSystem.Presentation.API.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
        }
    }
}
