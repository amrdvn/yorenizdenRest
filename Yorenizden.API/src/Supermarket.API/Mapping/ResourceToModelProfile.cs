using AutoMapper;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Models.Queries;
using Yorenizden.API.Resources;

namespace Yorenizden.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveKategoriResource, Kategori>();

            CreateMap<SaveÜrünResource, Ürün>()
                .ForMember(src => src.Birim, opt => opt.MapFrom(src => (OlcuBirimi)src.OlcuBirimi));

            CreateMap<ÜrünlerQueryResource, ÜrünlerQuery>();
        }
    }
}