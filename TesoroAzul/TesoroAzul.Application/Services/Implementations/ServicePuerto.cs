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
    public class ServicePuerto : IServicePuerto
    {
        private readonly IRepositoryPuerto _repository;
        private readonly IMapper _mapper;

        public ServicePuerto(IRepositoryPuerto repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PuertoDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMappped = _mapper.Map<PuertoDTO>(@object);
            return objectMappped;
        }

        public async Task<ICollection<PuertoDTO>> FindByNameAsync(string nombre)
        {
            var list = await _repository.FindByNameAsync(nombre);

            var collection = _mapper.Map<ICollection<PuertoDTO>>(list);

            return collection;
        }
    }
}
