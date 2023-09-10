using AutoMapper;
using RealEstateWeb.Models;
using RealEstateWeb.Models.Dto;

namespace RealEstateWeb
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<Estate, EstateDto>();
            CreateMap<EstateDto, Estate>();
            CreateMap<EstateDto,EstateCreateDto>().ReverseMap();
            CreateMap<Estate, EstateCreateDto>().ReverseMap();
            CreateMap<Estate, EstateUpdateDto>().ReverseMap();
            CreateMap<EstateDto, EstateUpdateDto>().ReverseMap();

            CreateMap<EstateNumber, EstateNumberDto>().ReverseMap();
            CreateMap<EstateNumber, EstateNumberCreateDto>().ReverseMap();
            CreateMap<EstateNumber, EstateNumberUpdateDto>().ReverseMap();
            CreateMap<EstateNumberDto, EstateNumberCreateDto>().ReverseMap();
            CreateMap<EstateNumberDto, EstateNumberUpdateDto>().ReverseMap();

        }
    }
}
