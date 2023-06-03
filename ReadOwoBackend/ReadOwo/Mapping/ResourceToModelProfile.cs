using AutoMapper;
using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.ReadOwo.Resources;

namespace ReadOwoBackend.ReadOwo.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveUserResource, User>();
    }
}