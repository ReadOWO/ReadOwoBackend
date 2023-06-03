using AutoMapper;
using ReadOwoBackend.ReadOwo.Domain.Models;
using ReadOwoBackend.ReadOwo.Resources;

namespace ReadOwoBackend.ReadOwo.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
    }
}