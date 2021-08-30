using AutoMapper;
using CicekSepetiStudyCase.Manager.Dtos;
using CicekSepetiStudyCase.Domain.Entities;

namespace CicekSepetiStudyCase.Manager.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {  
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<BasketDto, Basket>().ReverseMap(); 

            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
        }
    }
}
