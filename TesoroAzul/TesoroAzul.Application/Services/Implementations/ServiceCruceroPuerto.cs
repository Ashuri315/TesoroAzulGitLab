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
    public class ServiceCruceroPuerto : IServiceCruceroPuerto
    {
        private readonly IRepositoryCruceroPuerto _repository;
        private readonly IMapper _mapper;

        public ServiceCruceroPuerto(IRepositoryCruceroPuerto repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CruceroPuertoDTO> FindPuertoLlegada(int idCrucero)
        {
            var @object = await _repository.FindPuertoLlegada(idCrucero);
            var objectMappped = _mapper.Map<CruceroPuertoDTO>(@object);
            return objectMappped;
        }

        public async Task<CruceroPuertoDTO> FindPuertoSalida(int idCrucero)
        {
            var @object = await _repository.FindPuertoSalida(idCrucero);
            var objectMappped = _mapper.Map<CruceroPuertoDTO>(@object);
            return objectMappped;
        }
    }
}
