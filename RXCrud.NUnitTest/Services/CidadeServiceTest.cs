using Moq;
using System;
using AutoMapper;
using System.Linq;
using NUnit.Framework;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Exception;
using RXCrud.NUnitTest.Common;
using RXCrud.Service.Services;
using System.Collections.Generic;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.Domain.Interfaces.Services;

namespace RXCrud.NUnitTest.Services
{
    public class CidadeServiceTest
    {
        private IMapper _mapper;
        private Cidade _cidade;
        private ICidadeService _cidadeService;
        private Mock<ICidadeRepository> _mockCidadeRepository;

        public CidadeServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _mockCidadeRepository = new Mock<ICidadeRepository>();
            _cidadeService = new CidadeService(_mapper, _mockCidadeRepository.Object);
            _cidade = new Cidade("Fortaleza", Guid.NewGuid());
        }

        [Test]
        public void CriarComConstrutorTest()
            => Assert.IsNotNull(new CidadeDto("Fortaleza", Guid.NewGuid()));

        [Test]
        public void CriarTest()
        {
            _mockCidadeRepository.Setup(c => c.PesquisarPorNomeEEstado("Teresina", Guid.NewGuid())).Returns(_cidade);
            Assert.DoesNotThrow(() => _cidadeService.Criar(new CidadeDto("Manaus", Guid.NewGuid())));
        }

        [Test]
        public void CriarComNomeEEstadoJaCadastradosTest()
        {
            _mockCidadeRepository.Setup(c => c.PesquisarPorNomeEEstado(_cidade.Nome, _cidade.IdEstado)).Returns(_cidade);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _cidadeService.Criar(new CidadeDto(_cidade.Nome, _cidade.IdEstado)))
                .Message.Equals("A cidade informada já está sendo utilizada."));
        }

        [Test]
        public void CriarComNomeJaCadastradoEEstadoNaoCadastradoTest()
        {
            _mockCidadeRepository.Setup(c => c.PesquisarPorNomeEEstado(_cidade.Nome, _cidade.IdEstado)).Returns(_cidade);
            Assert.DoesNotThrow(() => _cidadeService.Atualizar(new CidadeDto(_cidade.Nome, Guid.NewGuid())));
        }

        [Test]
        public void AtualizarTest()
        {
            _mockCidadeRepository.Setup(c => c.PesquisarPorNomeEEstado("Teresina", Guid.NewGuid())).Returns(_cidade);
            Assert.DoesNotThrow(() => _cidadeService.Atualizar(new CidadeDto("São Paulo", Guid.NewGuid())));
        }

        [Test]
        public void AtualizarComNomeEEstadoJaCadastradosTest()
        {
            _mockCidadeRepository.Setup(c => c.PesquisarPorNomeEEstado(_cidade.Nome, _cidade.IdEstado)).Returns(_cidade);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _cidadeService.Atualizar(new CidadeDto(_cidade.Nome, _cidade.IdEstado)))
                .Message.Equals("A cidade informada já está sendo utilizada."));
        }

        [Test]
        public void AtualizarComNomeJaCadastradoEEstadoNaoCadastradoTest()
        {
            _mockCidadeRepository.Setup(c => c.PesquisarPorNomeEEstado(_cidade.Nome, _cidade.IdEstado)).Returns(_cidade);
            Assert.DoesNotThrow(() => _cidadeService.Atualizar(new CidadeDto(_cidade.Nome, Guid.NewGuid())));
        }

        [Test]
        public void AtualizarComNomeEEstadoJaCadastradosSemExcecaoTest()
        {
            _mockCidadeRepository.Setup(c => c.PesquisarPorNomeEEstado(_cidade.Nome, _cidade.IdEstado)).Returns(_cidade);
            Assert.DoesNotThrow(() => _cidadeService.Atualizar(_mapper.Map<CidadeDto>(_cidade)));
        }

        [Test]
        public void RemoverTest()
            => Assert.DoesNotThrow(() => _cidadeService.Remover(new CidadeDto("Fortaleza", Guid.NewGuid())));

        [Test]
        public void ObterTodosTest()
        {
            IList<Cidade> cidadesList = new List<Cidade>();
            cidadesList.Add(_cidade);

            _mockCidadeRepository.Setup(r => r.ObterTodos()).Returns(cidadesList.AsQueryable());
            Assert.IsNotNull(_cidadeService.ObterTodos());
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            _mockCidadeRepository.Setup(r => r.PesquisarPorId(_cidade.Id)).Returns(_cidade);
            Assert.IsNotNull(_cidadeService.PesquisarPorId(_cidade.Id));
        }
    }
}