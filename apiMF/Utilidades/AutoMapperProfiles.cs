using apiMF.Models;
using apiMF.Models.Request;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Utilidades
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Categoriaconsumible, CategoriaConsumibleRequest>().ReverseMap();
            CreateMap<CategoriaConsumibleCreacionDTO, Categoriaconsumible>();
        }
    }
}
