using AutoMapper;
using SocialMediaApp.Data.Dtoes;
using SocialMediaApp.Data.Models;

namespace SocialMediaApp.Business.Mapper
{
    public class AutoMapperDto : Profile
    {
        public AutoMapperDto()
        {
            CreateMap<UserModel, UserDto>();

            CreateMap<UserDto, UserModel>();

            CreateMap<AddressModel, AddressDto>()
                .ForMember(x => x.Owner, y => y.MapFrom(z => z.User.Name + " " + z.User.LastName));

            CreateMap<AddressDto, AddressModel>();
        }
    }
}
