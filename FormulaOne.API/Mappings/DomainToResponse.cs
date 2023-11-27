using AutoMapper;
using FormulaOne.API.Dtos.Responses;
using FormulaOne.Entities;

namespace FormulaOne.API.Mappings
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Achievement, AchievementResponse>()
                .ForMember(dest => dest.Wins, opt => opt.MapFrom(src => src.RaceWins));

            CreateMap<Driver, DriverResponse>()
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
