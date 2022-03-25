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

            CreateMap<Categoriaherramienta, CategoriaHerramientumRequest>().ReverseMap();
            CreateMap<CategoriaHerramientaCreacionDTO, Categoriaherramienta>();

            CreateMap<Tipousuario, TipoUsuarioRequest>().ReverseMap();
            CreateMap<TipoUsuarioCreacionDTO, Tipousuario>();

            CreateMap<Usuario, UsuarioRequest>().ReverseMap();
            CreateMap<UsuarioCreacionDTO, Usuario>();

            CreateMap<Usuario, CredencialesUsuario>().ReverseMap();

            CreateMap<Consumible, ConsumibleRequest>().ReverseMap();
            CreateMap<ConsumibleCreacionDTO, Consumible>().ForMember(x=>x.Imagen,options=>options.Ignore());
        }
    }
}
