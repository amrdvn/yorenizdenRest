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

            CreateMap<Save�r�nResource, �r�n>()
                .ForMember(src => src.Birim, opt => opt.MapFrom(src => (OlcuBirimi)src.OlcuBirimi));

            CreateMap<�r�nlerQueryResource, �r�nlerQuery>();
        }
    }
}