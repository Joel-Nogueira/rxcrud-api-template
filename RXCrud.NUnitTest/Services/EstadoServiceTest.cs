using AutoMapper;
using Moq;
using NUnit.Framework;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Exception;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.Domain.Interfaces.Services;
using RXCrud.NUnitTest.Common;
using RXCrud.Service.Services;
using System.Collections.Generic;
using System.Linq;

namespace RXCrud.NUnitTest.Services
{
    public class EstadoServiceTest
    {
        private IMapper _mapper;
        private Estado _estado;
        private IEstadoService _estadoService;
        private Mock<IEstadoRepository> _mockEstadoRepository;

        public EstadoServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _mockEstadoRepository = new Mock<IEstadoRepository>();
            _estadoService = new EstadoService(_mapper, _mockEstadoRepository.Object);
            _estado = new Estado("Ceará");
        }

        [Test]
        public void CriarComConstrutorTest()
            => Assert.IsNotNull(new EstadoDto("Ceará"));

        [Test]
        public void CriarTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorNome("Piauí")).Returns(_estado);
            Assert.DoesNotThrow(() => _estadoService.Criar(new EstadoDto("Amazonas")));
        }

        [Test]
        public void CriarComNomeJaCadastradoTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorNome(_estado.Nome)).Returns(_estado);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _estadoService.Criar(new EstadoDto("Ceará")))
                .Message.Equals("O estado informado já está sendo utilizado."));
        }

        [Test]
        public void AtualizarTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorNome("Piauí")).Returns(_estado);
            Assert.DoesNotThrow(() => _estadoService.Atualizar(new EstadoDto("São Paulo")));
        }

        [Test]
        public void AtualizarComNomeJaCadastradoTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorNome(_estado.Nome)).Returns(_estado);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _estadoService.Atualizar(new EstadoDto("Ceará")))
                .Message.Equals("O estado informado já está sendo utilizado."));
        }

        [Test]
        public void AtualizarComNomeJaCadastradoSemExcecaoTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorNome(_estado.Nome)).Returns(_estado);
            Assert.DoesNotThrow(() => _estadoService.Atualizar(_mapper.Map<EstadoDto>(_estado)));
        }

        [Test]
        public void RemoverTest()
            => Assert.DoesNotThrow(() => _estadoService.Remover(new EstadoDto("Ceará")));

        [Test]
        public void ObterTodosTest()
        {
            IList<Estado> estadosList = new List<Estado>();
            estadosList.Add(_estado);

            _mockEstadoRepository.Setup(r => r.ObterTodos()).Returns(estadosList.AsQueryable());
            Assert.IsNotNull(_estadoService.ObterTodos());
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorId(_estado.Id)).Returns(_estado);
            Assert.IsNotNull(_estadoService.PesquisarPorId(_estado.Id));
        }
    }
}