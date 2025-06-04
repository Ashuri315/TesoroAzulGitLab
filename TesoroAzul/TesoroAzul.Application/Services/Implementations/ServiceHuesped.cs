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
    public class ServiceHuesped : IServiceHuesped
    {
        private readonly IRepositoryHuesped _repository;
        private readonly IMapper _mapper;

        public ServiceHuesped(IRepositoryHuesped repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
