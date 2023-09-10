using AutoMapper;
using RealEstateWeb_MVC.Models;
using RealEstateWeb_MVC.Models.Dto;

namespace RealEstateWeb_MVC
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<Estate, EstateDto>();
            CreateMap<EstateDto, Estate>();
            CreateMap<EstateDto,EstateCreateDto>().ReverseMap();
            CreateMap<EstateDto, EstateUpdateDto>().ReverseMap();

            CreateMap<EstateNumber, EstateNumberDto>().ReverseMap();
            CreateMap<EstateNumber, EstateNumberCreateDto>().ReverseMap();
            CreateMap<EstateNumber, EstateNumberUpdateDto>().ReverseMap();
            CreateMap<EstateNumberDto, EstateNumberCreateDto>().ReverseMap();
            CreateMap<EstateNumberDto, EstateNumberUpdateDto>().ReverseMap();

        }
    }
}
