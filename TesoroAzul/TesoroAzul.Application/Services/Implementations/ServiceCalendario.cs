using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;
using TesoroAzul.Application.Services.Interfaces;
using TesoroAzul.Infraestructure.Repository.Interfaces;

namespace TesoroAzul.Application.Services.Implementations
{
    public class ServiceCalendario : IServiceCalendario
    {
        private readonly IRepositoryCalendario _repository;
        private readonly IMapper _mapper;

        public ServiceCalendario(IRepositoryCalendario repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CalendarioDTO> FindByIdAsync(DateOnly fechaInicio, int idCrucero)
        {
            var @object = await _repository.FindByIdAsync(fechaInicio, idCrucero);
            var objectMappped = _mapper.Map<CalendarioDTO>(@object);
            return objectMappped;
        }

        public async Task<DateOnly> CalculaFechaFin(DateOnly fechaInicio, int idCrucero)
        {
            var @calendario = await this.FindByIdAsync(fechaInicio, idCrucero);
            @calendario.FechaFin = fechaInicio.AddDays(@calendario.IdCruceroNavigation.CantidadDias);

            return @calendario.FechaFin;
        }
    }
}
