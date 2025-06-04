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
    public class ServicePais : IServicePais
    {
        private readonly IRepositoryPais _repository;
        private readonly IMapper _mapper;

        public ServicePais(IRepositoryPais repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
