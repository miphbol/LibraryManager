using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibManagerMVC.Data.Entities;
using LibManagerMVC.Models.Book;

namespace LibManagerMVC.Models.AutoMap;

public class BookMapProfile : Profile
{
    public BookMapProfile()
    {
        CreateMap<BookEntity, BookDetailViewModel>();
        CreateMap<BookEntity, BookIndexViewModel>();
        CreateMap<BookEntity, BookEditViewModel>();

        CreateMap<BookCreateViewModel, BookEntity>();
        CreateMap<BookEditViewModel, BookEntity>();
    }
}

