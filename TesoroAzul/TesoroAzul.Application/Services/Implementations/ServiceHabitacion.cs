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
    public class ServiceHabitacion : IServiceHabitacion
    {
        private readonly IRepositoryHabitacion _repository;
        private readonly IMapper _mapper;

        public ServiceHabitacion(IRepositoryHabitacion repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<HabitacionDTO>> ListAsync()
        {
            //Obtiene los datos del repositorio
            var list = await _repository.ListAsync();

            //Mapea la lista del modelo a la lista del DTO
            var collection = _mapper.Map<ICollection<HabitacionDTO>>(list);

            return collection;
        }
        public async Task<HabitacionDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMappped = _mapper.Map<HabitacionDTO>(@object);
            return objectMappped;
        }

        public async Task<int> AddAsync(HabitacionDTO dto)
        {
            // Map LibroDTO to Libro
            var objectMapped = _mapper.Map<Habitacion>(dto);

            // Return
            return await _repository.AddAsync(objectMapped);
        }

        public async Task UpdateAsync(int id, HabitacionDTO dto)
        {
            //Obtenga el modelo original a actualizar
            var @object = await _repository.FindByIdAsync(id);
            //       source, destination
            var entity = _mapper.Map(dto, @object!);


            await _repository.UpdateAsync(entity);
        }

        public async Task<bool> AnyAsync(string nombre)
        {
            return await _repository.AnyAsync(nombre);
        }

        public async Task<ICollection<HabitacionDTO>> FindByNameAsync(string nombre)
        {
            var list = await _repository.FindByNameAsync(nombre);

            var collection = _mapper.Map<ICollection<HabitacionDTO>>(list);

            return collection;

        }
    }
}
