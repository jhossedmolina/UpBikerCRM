using AutoMapper;
using UpBikerCRM.Core.DTOs;
using UpBikerCRM.Core.Entities;

namespace UpBikerCRM.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductoDto, Inventario.Producto>();
            CreateMap<Inventario.Producto, ProductoDto>();
        }
    }
}
