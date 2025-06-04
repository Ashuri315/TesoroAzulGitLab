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
    public class ServiceReservaComplemento : IServiceReservaComplemento
    {
        private readonly IRepositoryReservaComplemento _repository;
        private readonly IMapper _mapper;

        public ServiceReservaComplemento(IRepositoryReservaComplemento repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReservaComplementoDTO> FindByIdAsync(int idReserva, int idComplemento)
        {
            var @object = await _repository.FindByIdAsync(idReserva, idComplemento);
            var objectMappped = _mapper.Map<ReservaComplementoDTO>(@object);
            return objectMappped;
        }

        public async Task<int> CalculaTotalComplemento(ReservaComplementoDTO reservaComp)
        {
            var @reservacom = await this.FindByIdAsync(reservaComp.IdReserva, reservaComp.IdComplemento);
            reservacom.TotalComp = reservacom.Cantidad * reservacom.IdComplementoNavigation.Precio;

            return reservacom.TotalComp;
        }
    }
}
