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
    public class ServiceCrucero : IServiceCrucero
    {
        private readonly IRepositoryCrucero _repository;
        private readonly IMapper _mapper;

        public ServiceCrucero(IRepositoryCrucero repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<CruceroDTO>> ListAsync()
        {
            //Obtiene los datos del repositorio
            var list = await _repository.ListAsync();

            //Mapea la lista del modelo a la lista del DTO
            var collection = _mapper.Map<ICollection<CruceroDTO>>(list);

            return collection;
        }
        public async Task<CruceroDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMappped = _mapper.Map<CruceroDTO>(@object);
            return objectMappped;
        }

        public async Task<int> AddAsync(CruceroDTO dto)
        {
            var @object = _mapper.Map<Crucero>(dto);
            return await _repository.AddAsync(@object);
        }

        public async Task<ICollection<CruceroDTO>> CruisesForHome()
        {
            //Obtiene los datos del repositorio
            var list = await _repository.CruisesForHome();

            //Mapea la lista del modelo a la lista del DTO
            var collection = _mapper.Map<ICollection<CruceroDTO>>(list);

            return collection;
        }

        public async Task<ICollection<CruceroDTO>> getCrucerosDisponibles()
        {
            var list = await _repository.getCrucerosDisponibles();

            //Mapea la lista del modelo a la lista del DTO
            var collection = _mapper.Map<ICollection<CruceroDTO>>(list);

            return collection;
        }
    }
}
