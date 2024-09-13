using AutoMapper;
using HostGallery.Application.Dtos.Categoria;
using HostGallery.Application.Dtos.Item;
using HostGallery.Domain.Entities;

namespace HostGallery.Application.Mappings; 

public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        CreateMap<Item, ItemDTO>().ReverseMap();
        CreateMap<Categoria, CategoriaDTO>().ReverseMap(); 
    }
}
