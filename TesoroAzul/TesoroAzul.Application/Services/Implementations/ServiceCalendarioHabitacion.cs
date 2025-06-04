using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;
using TesoroAzul.Application.Services.Interfaces;
using TesoroAzul.Infraestructure.Models;
using TesoroAzul.Infraestructure.Repository.Implementations;
using TesoroAzul.Infraestructure.Repository.Interfaces;

namespace TesoroAzul.Application.Services.Implementations
{
    public class ServiceCalendarioHabitacion : IServiceCalendarioHabitacion
    {
        private readonly IRepositoryCalendarioHabitacion _repository;
        private readonly IMapper _mapper;

        public ServiceCalendarioHabitacion(IRepositoryCalendarioHabitacion repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CalendarioHabitacionDTO> getCalendarioHabitacion(int idHabitacion, int idCrucero, DateOnly fechaInicio)
        {
            var @object = await _repository.getCalendarioHabitacion(idHabitacion, idCrucero, fechaInicio);
            var objectMappped = _mapper.Map<CalendarioHabitacionDTO>(@object);
            return objectMappped;
        }

        public async Task<ICollection<CalendarioHabitacionDTO>> getHabitacionesDisponibles(int idCrucero, DateOnly fechaInicio)
        {
            var list = await _repository.getHabitacionesDisponibles(idCrucero, fechaInicio);

            //Mapea la lista del modelo a la lista del DTO
            var collection = _mapper.Map<ICollection<CalendarioHabitacionDTO>>(list);

            return collection;
        }

        public async Task UpdateAsync(int idHabitacion, int idCrucero, DateOnly fechaInicio, CalendarioHabitacionDTO dto)
        {
            var @object = await _repository.getCalendarioHabitacion(idHabitacion, idCrucero, fechaInicio);

            var entity = _mapper.Map(dto, @object);

            await _repository.UpdateAsync(entity);
        }

    }
}
