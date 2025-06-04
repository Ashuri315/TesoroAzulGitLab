using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoroAzul.Application.Services.Interfaces;
using TesoroAzul.Infraestructure.Repository.Interfaces;
using TesoroAzul.Application.Config;
using TesoroAzul.Application.DTOs;
using TesoroAzul.Application.Utils;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Application.Services.Implementations
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IRepositoryUsuario _repository;
        private readonly IMapper _mapper;
        private readonly IOptions<AppConfig> _options;

        public ServiceUsuario(IRepositoryUsuario repository, IMapper mapper, IOptions<AppConfig> options)
        {
            _repository = repository;
            _mapper = mapper;
            _options = options;
        }

        public async Task<string> AddAsync(UsuarioDTO dto)
        {
            // Llave secreta
            string secret = _options.Value.Crypto.Secret;
            // Password encriptado
            string passwordEncrypted = Cryptography.Encrypt(dto.Contrasena!, secret);
            // Establecer password DTO
            dto.Contrasena = passwordEncrypted;
            var objectMapped = _mapper.Map<Usuario>(dto);

            return await _repository.AddAsync(objectMapped);
        }

        public async Task<UsuarioDTO> FindByIdAsync(string id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<UsuarioDTO>(@object);
            return objectMapped;
        }

        public async Task<UsuarioDTO> LoginAsync(string id, string contrasenna)
        {
            UsuarioDTO usuarioDTO = null!;

            // Llave secreta
            string secret = _options.Value.Crypto.Secret;
            // Password encriptado
            string passwordEncrypted = Cryptography.Encrypt(contrasenna, secret);

            var @object = await _repository.LoginAsync(id, passwordEncrypted);

            if (@object != null)
            {
                usuarioDTO = _mapper.Map<UsuarioDTO>(@object);
            }

            return usuarioDTO;
        }
    }
}
