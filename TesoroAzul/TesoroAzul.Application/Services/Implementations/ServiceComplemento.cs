using AutoMapper;
using TesoroAzul.Application.DTOs;
using TesoroAzul.Application.Services.Interfaces;
using TesoroAzul.Infraestructure.Models;
using TesoroAzul.Infraestructure.Repository.Interfaces;

namespace TesoroAzul.Application.Services.Implementations
{
    public class ServiceComplemento : IServiceComplemento
    {
        private readonly IRepositoryComplemento _repository;
        private readonly IMapper _mapper;

        public ServiceComplemento(IRepositoryComplemento repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<ComplementoDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();

            //Mapea la lista del modelo a la lista del DTO
            var collection = _mapper.Map<ICollection<ComplementoDTO>>(list);

            //Para calcular el total de habitaciones


            return collection;
        }

        public async Task<ComplementoDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMappped = _mapper.Map<ComplementoDTO>(@object);
            return objectMappped;
        }

        public async Task<ICollection<ComplementoDTO>> GetComplementosHabitacion()
        {
            var list = await _repository.GetComplementosHabitacion();

            //Mapea la lista del modelo a la lista del DTO
            var collection = _mapper.Map<ICollection<ComplementoDTO>>(list);

            //Para calcular el total de habitaciones


            return collection;
        }

        public async Task<ICollection<ComplementoDTO>> GetComplementosPasajero()
        {
            var list = await _repository.GetComplementosPasajero();

            //Mapea la lista del modelo a la lista del DTO
            var collection = _mapper.Map<ICollection<ComplementoDTO>>(list);

            //Para calcular el total de habitaciones


            return collection;
        }

        public async Task<int> AddAsync(ComplementoDTO dto)
        {
            // Map LibroDTO to Libro
            var objectMapped = _mapper.Map<Complemento>(dto);

            // Return
            return await _repository.AddAsync(objectMapped);
        }

        public async Task UpdateAsync(int id, ComplementoDTO dto)
        {
            //Obtenga el modelo original a actualizar
            var @object = await _repository.FindByIdAsync(id);
            //       source, destination
            var entity = _mapper.Map(dto, @object!);


            await _repository.UpdateAsync(entity);
        }
    }
}
