using AutoMapper;
using WorldAPI.DTO.Country;
using WorldAPI.DTO.State;
using WorldAPI.Model;

namespace WorldAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<CountryDTO, Country>().ReverseMap();
            CreateMap<GetCountryDTO, Country>().ReverseMap();
            CreateMap<UpdateCountryDTO, Country>().ReverseMap();
            CreateMap<CreateStateDTO, State>().ReverseMap();
            CreateMap<GetStateDTO, State>().ReverseMap();
            CreateMap<UpdateStateDTO, State>().ReverseMap();

        }
    }
}
