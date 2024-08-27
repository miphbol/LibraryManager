using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibManagerMVC.Data.Entities;
using LibManagerMVC.Models.Loan;

namespace LibManagerMVC.Models.AutoMap;

public class LoanMapProfile : Profile
{
    public LoanMapProfile()
    {
        CreateMap<LoanEntity, LoanDetailViewModel>();
        CreateMap<LoanEntity, LoanIndexViewModel>();
        CreateMap<LoanEntity, LoanEditViewModel>();

        CreateMap<LoanCreateViewModel, LoanEntity>();
        CreateMap<LoanEditViewModel, LoanEntity>();
    }
}