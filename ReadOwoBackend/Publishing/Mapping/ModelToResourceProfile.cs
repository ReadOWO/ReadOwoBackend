using AutoMapper;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Services.Communication;
using ReadOwoBackend.Publishing.Resources;

namespace ReadOwoBackend.Publishing.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Genre, GenreResource>();
        CreateMap<Language, LanguageResource>();
        CreateMap<Saga, SagaResource>();
        CreateMap<SagaStatus, SagaStatusResource>();
        CreateMap<Book, BookResource>();
        CreateMap<BookStatus, BookStatusResource>();
        CreateMap<BookGenre, BookGenreResource>();
    }
}