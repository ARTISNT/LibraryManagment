using Application.Dto.BookDto;
using AutoMapper;
using Domain.Models.Entities;

namespace Application.Mapping.AutoMappingProfiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookEntity, BookDtoResponse>();
        CreateMap<CreateBookDto, BookEntity>();
        CreateMap<UpdateBookDto, BookEntity>();
    }
}