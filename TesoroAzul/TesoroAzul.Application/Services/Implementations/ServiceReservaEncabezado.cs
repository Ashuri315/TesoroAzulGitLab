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
    public class ServiceReservaEncabezado : IServiceReservaEncabezado
    {
        private readonly IRepositoryReservaEncabezado _repository;
        private readonly IRepositoryCruceroPuerto _repositoryCruceroPuerto;
        private readonly IServiceCalendario _serviceCalendario;
        private readonly IServiceReservaComplemento _serviceReservaComplemento;
        private readonly IMapper _mapper;

        public ServiceReservaEncabezado(IRepositoryReservaEncabezado repository, IRepositoryCruceroPuerto repositoryCruceroPuerto, IServiceCalendario serviceCalendario, IServiceReservaComplemento serviceReservaComplemento, IMapper mapper)
        {
            _repository = repository;
            _repositoryCruceroPuerto = repositoryCruceroPuerto;
            _serviceCalendario = serviceCalendario;
            _serviceReservaComplemento = serviceReservaComplemento;
            _mapper = mapper;
        }

        public async Task<ICollection<ReservaEncabezadoDTO>> ListAsync()
        {
            //Obtiene los datos del repositorio
            var list = await _repository.ListAsync();

            //Mapea la lista del modelo a la lista del DTO
            var collection = _mapper.Map<ICollection<ReservaEncabezadoDTO>>(list);

            return collection;
        }
        public async Task<ReservaEncabezadoDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMappped = _mapper.Map<ReservaEncabezadoDTO>(@object);

            //Para que salga el estado de pago
            if (objectMappped.Pendiente)
            {
                objectMappped.estado_pago = "Pendiente";
            } else
            {
                objectMappped.estado_pago = "Pagado";
            }
            //Para el puerto de salida
            var @idCrucero = objectMappped.IdCrucero;
            var @cruceroPSalida = await _repositoryCruceroPuerto.FindPuertoSalida(@idCrucero);
            var @cruceroPLlegada = await _repositoryCruceroPuerto.FindPuertoLlegada(@idCrucero);

            objectMappped.Calendario.IdCruceroNavigation.puertoSalida = _mapper.Map<CruceroPuertoDTO>(@cruceroPSalida);
            objectMappped.Calendario.IdCruceroNavigation.puertoLlegada = _mapper.Map<CruceroPuertoDTO>(@cruceroPLlegada);

            //Para la fecha final
            var @fechaInicio = objectMappped.Calendario.FechaInicio;
            objectMappped.Calendario.FechaFin = await _serviceCalendario.CalculaFechaFin(@fechaInicio, @idCrucero);

            //Para el complemento
            if (objectMappped.ReservaComplemento.Count != 0)
            {
                var @reservaComp = objectMappped.ReservaComplemento;
                foreach (var item in reservaComp)
                {
                    item.TotalComp = await _serviceReservaComplemento.CalculaTotalComplemento(item);
                }
            }
            return objectMappped;
        }

        public async Task<int> AddAsync(ReservaEncabezadoDTO dto)
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

            var @object = _mapper.Map<ReservaEncabezado>(dto);
            return await _repository.AddAsync(@object);
        }
    }
}
