using AutoMapper;
using Business.Features.Products.Commands.Create;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
        }
    }
}
