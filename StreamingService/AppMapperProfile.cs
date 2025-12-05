using AutoMapper;
using StreamingService.DTO;
using StreamingService.Models;

namespace StreamingService
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<UserProfileViewModel, UserProfile>();
        }
    }
}
