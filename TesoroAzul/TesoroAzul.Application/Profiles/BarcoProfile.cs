using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.Profiles
{
    public class BarcoProfile : Profile
    {
        public BarcoProfile()
        {
            CreateMap<BarcoDTO, Barco>().ReverseMap();
        }
    }
}
