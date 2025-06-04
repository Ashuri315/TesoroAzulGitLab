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
    public class ServiceCuentaCobrar : IServiceCuentaCobrar
    {
        private readonly IRepositoryCuentaCobrar _repository;
        private readonly IMapper _mapper;

        public ServiceCuentaCobrar(IRepositoryCuentaCobrar repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CuentaCobrarDTO dto)
        {
            var @object = _mapper.Map<CuentaCobrar>(dto);
            return await _repository.AddAsync(@object);
        }
    }
}
