

namespace MoviesApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMovieDto, Movie>()
              .ForMember(src => src.Posters, opt => opt.Ignore());
        }
    }
}