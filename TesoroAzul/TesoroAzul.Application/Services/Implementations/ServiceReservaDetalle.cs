using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.Services.Interfaces;
using TesoroAzul.Infraestructure.Repository.Interfaces;

namespace TesoroAzul.Application.Services.Implementations
{
    public class ServiceReservaDetalle : IServiceReservaDetalle
    {
        private readonly IRepositoryReservaDetalle _repository;
        private readonly IMapper _mapper;

        public ServiceReservaDetalle(IRepositoryReservaDetalle repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
