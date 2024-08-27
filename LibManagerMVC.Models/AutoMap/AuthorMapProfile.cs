using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibManagerMVC.Data.Entities;
using LibManagerMVC.Models.Author;

namespace LibManagerMVC.Models.AutoMap;

public class AuthorMapProfile : Profile
{
    public AuthorMapProfile()
    {
        CreateMap<AuthorEntity, AuthorDetailViewModel>();
        CreateMap<AuthorEntity, AuthorIndexViewModel>();
        CreateMap<AuthorEntity, AuthorEditViewModel>();

        CreateMap<AuthorCreateViewModel, AuthorEntity>();
        CreateMap<AuthorEditViewModel, AuthorEntity>();
    }
}