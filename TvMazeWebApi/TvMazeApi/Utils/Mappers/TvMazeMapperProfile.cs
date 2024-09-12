using AutoMapper;
using System.Globalization;
using TvMazeApi.ShowsApi.Models;
using TvMazeApi.TvMazeData.Entities;

namespace TvMazeApi.Utils.Mappers
{
    public class TvMazeMapperProfile : Profile
    {
        public TvMazeMapperProfile()
        {
            CreateMap<TvMazeShow, Show>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.url))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.type))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.language))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status))
                .ForMember(dest => dest.Runtime, opt => opt.MapFrom(src => src.runtime))
                .ForMember(dest => dest.AverageRuntime, opt => opt.MapFrom(src => src.averageRuntime))
                .ForMember(dest => dest.Ended, opt => opt.MapFrom(
                    src => DateTime.ParseExact(src.ended, "yyyy-MM-dd", CultureInfo.InvariantCulture))
                );
        }
    }
}
