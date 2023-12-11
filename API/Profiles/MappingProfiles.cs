using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() // Remember adding : Profile in the class
        {
            CreateMap<Categoriapersona, CategoriaPersonaDto>().ReverseMap();

            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<Contactopersona, ContactoPersonaDto>().ReverseMap();

            CreateMap<Contrato, ContratoDto>().ReverseMap();

            CreateMap<Departamento, DepartamentoDto>().ReverseMap();

            CreateMap<Direccionpersona, DireccionPersonaDto>().ReverseMap();

            CreateMap<Estado, EstadoDto>().ReverseMap();

            CreateMap<Persona, PersonaDto>().ReverseMap();

            CreateMap<Pais, PaisDto>().ReverseMap();

            CreateMap<Programacion, ProgramacionDto>().ReverseMap();

            CreateMap<Tipocontacto, TipoContactoDto>().ReverseMap();

            CreateMap<Tipodireccion, TipoDireccionDto>().ReverseMap();

            CreateMap<Tipopersona, TipoPersonaDto>().ReverseMap();

            CreateMap<Turno, TurnoDto>().ReverseMap();

        }
    }
}