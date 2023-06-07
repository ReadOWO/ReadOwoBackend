using AutoMapper;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Resources;

namespace ReadOwoBackend.Publishing.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Genre, GenreResource>();
    }
}