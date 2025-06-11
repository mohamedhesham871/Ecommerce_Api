using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dtos.Prodcut;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Domain.Models.productMoulde;
namespace Services.MappingProfile
{
    public  class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // i want to put full path of picture Url in mapping 
            //Source , Distination
            CreateMap<Product, ProdcutResponse>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.ProductType.Name)).
                ForMember(dest => dest.PictureUrl, option => option.MapFrom<pictureUrlResolver>());
            //  ForMember(dest => dest.PictureUrl, option => option.MapFrom(src => $"https://localhost:7223/{src.PictureUrl}"));

            CreateMap<ProductBrand, BrandResponse>().ReverseMap();
            CreateMap<ProductType, TypeResponse>().ReverseMap();
        }
    }
    public class pictureUrlResolver(IConfiguration _config) : IValueResolver<Product, ProdcutResponse, string>
    {
 
         public string Resolve(Product source, ProdcutResponse destination, string destMember,ResolutionContext context)
         {
            if (!string.IsNullOrWhiteSpace(source.PictureUrl))
            {
                return $"{_config["BaseUrl"]}{source.PictureUrl}";
            }
            return string.Empty;
         }

        
    }

}
