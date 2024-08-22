using AutoMapper;
using BackEndCRUD.DTOs;
using BackEndCRUD.Models;
using System.Globalization;

namespace BackEndCRUD.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Director
            CreateMap<Director, DirectorDTO>().ReverseMap();
            #endregion

            #region Movie
            CreateMap<Movie, MovieDTO>()
                .ForMember(destino =>
                destino.Director,
                opt => opt.MapFrom(origen => origen.DirectorKeyNavigation.DirectorName)
                )
                .ForMember(destino =>
                destino.Duration,
                opt => opt.MapFrom(origen => origen.Duration.Value.ToString("hh\\:mm\\:ss"))
               );

            CreateMap<MovieDTO, Movie>()
                .ForMember(destino =>
                destino.DirectorKeyNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.Duration,
                opt => opt.MapFrom(origen => TimeSpan.ParseExact(origen.Duration, "hh\\:mm\\:ss", CultureInfo.InvariantCulture))
                );

            #endregion

        }
    }
}
