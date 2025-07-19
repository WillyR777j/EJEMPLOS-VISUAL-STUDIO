using ApiEstudiantes.DTOs;
using ApiEstudiantes.Models;
using AutoMapper;

namespace ApiEstudiantes.Servicios
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {         
             CreateMap<Estudiante, EstudianteCreacionDTO>(); // Solo toma los campos que estén en el destino (DTO)
            CreateMap<EstudianteCreacionDTO, Estudiante>() // Si necesitas mapear de vuelta
                .ForMember(dest => dest.FechaCreado, opt => opt.Ignore())
                .ForMember(dest => dest.FechaModificado, opt => opt.Ignore());
        }
    }
}
