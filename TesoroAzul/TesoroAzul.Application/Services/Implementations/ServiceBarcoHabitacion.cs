using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.DTOs;
using TesoroAzul.Application.Services.Interfaces;
using TesoroAzul.Infraestructure.Models;
using TesoroAzul.Infraestructure.Repository.Interfaces;

namespace TesoroAzul.Application.Services.Implementations
{
    public class ServiceBarcoHabitacion : IServiceBarcoHabitacion
    {
        private readonly IRepositoryBarcoHabitacion _repository;
        private readonly IMapper _mapper;

        public ServiceBarcoHabitacion(IRepositoryBarcoHabitacion repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<BarcoHabitacionDTO>> HabitacionesByBarcoId(int id)
        {
            var list = await _repository.HabitacionesByBarcoId(id);
            var collection = _mapper.Map<ICollection<BarcoHabitacionDTO>>(list);
            return collection;
        }
    }
}
