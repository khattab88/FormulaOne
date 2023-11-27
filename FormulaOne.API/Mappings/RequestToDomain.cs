using AutoMapper;
using FormulaOne.API.Dtos.Requests;
using FormulaOne.Entities;

namespace FormulaOne.API.Mappings
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateAchievementRequest, Achievement>()
                .ForMember(dest => dest.RaceWins, opt => opt.MapFrom(src => src.Wins))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));

            CreateMap<UpdateAchievementRequest, Achievement>()
                .ForMember(dest => dest.RaceWins, opt => opt.MapFrom(src => src.Wins))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<CreateDriverRequest, Driver>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));

            CreateMap<UpdateDriverRequest, Driver>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
