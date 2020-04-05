using AutoMapper;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Models.Queries;
using Yorenizden.API.Extensions;
using Yorenizden.API.Resources;

namespace Yorenizden.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Kategori, KategoriResource>();

            CreateMap<Ürün, ÜrünResource>()
                .ForMember(src => src.OlcuBirimi,
                           opt => opt.MapFrom(src => src.Birim.ToDescriptionString()));

            CreateMap<QueryResult<Ürün>, QueryResultResource<ÜrünResource>>();
        }
    }
}