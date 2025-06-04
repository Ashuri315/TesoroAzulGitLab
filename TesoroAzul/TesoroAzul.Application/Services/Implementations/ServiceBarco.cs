using AutoMapper;
using AutoMapper.Internal.Mappers;
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
    public class ServiceBarco : IServiceBarco
    {
        private readonly IRepositoryBarco _repository;
        private readonly IMapper _mapper;

        public ServiceBarco(IRepositoryBarco repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<BarcoDTO>> ListAsync()
        {
            //Obtiene los datos del repositorio
            var list = await _repository.ListAsync();

            //Mapea la lista del modelo a la lista del DTO
            var collection = _mapper.Map<ICollection<BarcoDTO>>(list);

            //Para calcular el total de habitaciones
            foreach (var item in collection)
            {
                item.totalHabitaciones = this.CalculaTotalHabitaciones(item);
            }


            return collection;
        }
        public async Task<BarcoDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMappped = _mapper.Map<BarcoDTO>(@object);
            objectMappped.totalHabitaciones = this.CalculaTotalHabitaciones(objectMappped);
            return objectMappped;
        }

        public int CalculaTotalHabitaciones(BarcoDTO barco)
        {
            foreach (var item in barco.BarcoHabitacion)
            {
                barco.totalHabitaciones += item.Cantidad;
            }

            return barco.totalHabitaciones;
        }

        public async Task<int> AddAsync(BarcoDTO dto)
        {
            // Validar Stock disponible
            //foreach (var item in dto.OrdenDetalle)
            //{
            //    var Libro = await _repositoryLibro.FindByIdAsync(item.IdLibro);

            //    if (Libro.Cantidad - item.Cantidad < 0)
            //    {
            //        throw new Exception($"No hay stock para el Libro {Libro.Nombre}, cantidad en stock {Libro.Cantidad} ");
            //    }
            //}

            var @object = _mapper.Map<Barco>(dto);
            return await _repository.AddAsync(@object);
        }

        public async Task UpdateAsync(int id, BarcoDTO dto)
        {
            var @object = await _repository.FindByIdAsync(id);
            //       source, destination
            var entity = _mapper.Map(dto, @object!);


            await _repository.UpdateAsync(entity);
        }

        public async Task<bool> AnyAsync(string nombre)
        {
            return await _repository.AnyAsync(nombre);
        }

        public async Task<ICollection<BarcoDTO>> FindByNameAsync(string nombre)
        {
            var list = await _repository.FindByNameAsync(nombre);

            var collection = _mapper.Map<ICollection<BarcoDTO>>(list);

            return collection;

        }
    }
}