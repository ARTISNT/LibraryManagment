using Application.Dto.AuthorsDto;
using AutoMapper;
using Domain.Models.Entities;

namespace Application.Mapping.AutoMappingProfiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<AuthorEntity, AuthorResponseDto>();
        CreateMap<CreateAuthorDto, AuthorEntity>();
        CreateMap<UpdateAuthorDto, AuthorEntity>();
    }
}