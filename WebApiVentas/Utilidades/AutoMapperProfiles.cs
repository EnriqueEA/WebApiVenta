using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Core.DTOs;
using WebApiVentas.Core.Models;

namespace WebApiVentas.Utilidades
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Imagen, ImagenDto>().ReverseMap();
            CreateMap<ImagenCreacionDto, Imagen>()
                .ForMember(x => x.Url, options => options.Ignore());
        }
    }
}
