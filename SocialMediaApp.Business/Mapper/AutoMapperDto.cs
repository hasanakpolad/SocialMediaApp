using AutoMapper;
using SocialMediaApp.Data.Dtoes;
using SocialMediaApp.Data.Models;

namespace SocialMediaApp.Business.Mapper
{
    public class AutoMapperDto : Profile
    {
        public AutoMapperDto()
        {
            CreateMap<UserModel, UserDto>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Gender, y => y.MapFrom(z => z.Gender))
                .ForMember(x => x.BirthDate, y => y.MapFrom(z => z.BirthDate))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role))
                .ForMember(x => x.FollowCount, y => y.MapFrom(z => z.FollowCount))
                .ForMember(x => x.FollowerCount, y => y.MapFrom(z => z.FollowerCount))
                .ForMember(x => x.Addresses, y => y.MapFrom(z => z.Addresses));

            CreateMap<UserDto, UserModel>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Gender, y => y.MapFrom(z => z.Gender))
                .ForMember(x => x.BirthDate, y => y.MapFrom(z => z.BirthDate))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role))
                .ForMember(x => x.FollowCount, y => y.MapFrom(z => z.FollowCount))
                .ForMember(x => x.FollowerCount, y => y.MapFrom(z => z.FollowerCount));

            CreateMap<AddressModel, AddressDto>()
                .ForMember(x => x.Owner, y => y.MapFrom(z => z.User.Name + " " + z.User.LastName));

            CreateMap<AddressDto, AddressModel>();
        }
    }
}
