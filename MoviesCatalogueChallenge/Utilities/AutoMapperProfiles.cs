using AutoMapper;
using MoviesCatalogueChallenge.DTOs;
using MoviesCatalogueChallenge.Entities;

namespace MoviesCatalogueChallenge.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<MoviePostRequestDTO, Movie>();
            CreateMap<UserCreateDTO, User>();
        }
    }
}
