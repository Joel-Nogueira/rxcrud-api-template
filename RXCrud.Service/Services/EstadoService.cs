using AutoMapper;
using AutoMapper.QueryableExtensions;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Exception;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace RXCrud.Service.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IMapper mapper, IEstadoRepository estadoRepository)
        {
            _mapper = mapper;
            _estadoRepository = estadoRepository;
        }

        public void Criar(EstadoDto estadoDto)
        {
            NomeJaCadastrado(estadoDto);
            _estadoRepository.Criar(_mapper.Map<Estado>(estadoDto));
        }

        public void Atualizar(EstadoDto estadoDto)
        {
            NomeJaCadastrado(estadoDto);

            _estadoRepository.Atualizar(_mapper.Map<Estado>(estadoDto));
        }

        private void NomeJaCadastrado(EstadoDto estadoDto)
        {
            Estado estado = _estadoRepository.PesquisarPorNome(estadoDto.Nome);
            if ((estado != null) && (estado.Id != estadoDto.Id))
            {
                throw new RXCrudException("O estado informado já está sendo utilizado.");
            }
        }

        public void Remover(EstadoDto estadoDto)
            => _estadoRepository.Remover(_mapper.Map<Estado>(estadoDto));

        public IQueryable<EstadoDto> ObterTodos()
            => _estadoRepository.ObterTodos().ProjectTo<EstadoDto>(_mapper.ConfigurationProvider);

        public EstadoDto PesquisarPorId(Guid id)
            => _mapper.Map<EstadoDto>(_estadoRepository.PesquisarPorId(id));

        public EstadoDto PesquisarPorNome(string nome)
        {
            EstadoDto estadoDto = _mapper.Map<EstadoDto>(_estadoRepository.PesquisarPorNome(nome));

            if (estadoDto == null)
            {
                throw new RXCrudException("Estado não localizado.");
            }

            return estadoDto;
        }
    }
}