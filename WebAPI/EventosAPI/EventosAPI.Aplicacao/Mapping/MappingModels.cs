using AutoMapper;
using EventosAPI.Aplicacao.Modelos;
using EventosAPI.Domain.Modelos;
using EventosAPI.Infra.CrossCutting.Integracao;

namespace EventosAPI.Aplicacao.Mapping
{
    public class MappingModels : Profile
    {
        public MappingModels()
        {
            CreateMap<Convidado, ConvidadoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.ConvidadoId)).ReverseMap();

            CreateMap<Evento, EventoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.EventoId)).ReverseMap();

            CreateMap<Lote, LoteDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.LoteId)).ReverseMap();

            CreateMap<Palestrante, PalestranteDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.PalestranteId)).ReverseMap();

            CreateMap<PalestranteEvento, PalestranteEventoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id)).ReverseMap();

            CreateMap<RedeSocial, RedeSocialDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.RedeSocialId)).ReverseMap();

            CreateMap<ResponseViaCep, ResponseViaCepDTO>().ReverseMap();
        }
    }
}
