
using AutoMapper;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Resources;

namespace ReadOwoBackend.Publishing.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveGenreResource, Genre>();
        CreateMap<SaveLanguageResource, Language>();
        CreateMap<SaveSagaResource, Saga>();
        CreateMap<SaveSagaStatusResource, SagaStatus>();
    }
}