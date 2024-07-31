using AutoMapper;
using NotificationServiceSystem.Core.Entities;
using NotificationServiceSystem.Presentation.API.DTOs;

namespace NotificationServiceSystem.Presentation.API.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Notification, NotificationDTO>().ReverseMap();
        }
    }
}
