using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Exception;
using RXCrud.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace RXCrud.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _cidadeService;

        public CidadeController(ICidadeService cidadeService)
            => _cidadeService = cidadeService;

        /// <summary>
        /// Consulta
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet]
        [EnableQuery()]
        [ProducesResponseType(typeof(IQueryable<CidadeDto>), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Get()
            => Ok(_cidadeService.ObterTodos());

        /// <summary>
        /// Consulta por id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CidadeDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult PorId(Guid id)
        {
            CidadeDto cidade = _cidadeService.PesquisarPorId(id);
            if (cidade == null)
            {
                return NotFound();
            }

            return Ok(cidade);
        }

        /// <summary>
        /// Criar.
        /// Caso seja passado um array com id’s dos perfis que o usuário deve possuir os mesmos serão incluídos no usuário criado.
        /// Caso não seja passado nada será feito.
        /// </summary>
        /// <param name="cidade"></param>
        /// <response code="200">Criado com sucesso.</response>
        /// <response code="400">Não foi possível criar.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Post(CidadeDto cidade)
        {
            if (!ModelState.IsValid)
            {
                throw new RXCrudException("Os dados para criação são inválidos.");
            }

            _cidadeService.Criar(cidade);
            return Ok();
        }

        /// <summary>
        /// Atualizar.
        /// Caso seja passado um array com id’s dos perfis que o usuário deve possuir, todos os perfis atuais serão removidos e os novos serão incluídos.
        /// Caso não seja passado nada será feito.
        /// </summary>
        /// <param name="cidade"></param>
        /// <response code="200">Atualizado com sucesso.</response>
        /// <response code="400">Não foi possível atualizar.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Put(CidadeDto cidade)
        {
            if (!ModelState.IsValid)
            {
                throw new RXCrudException("Os dados para atualização são inválidos.");
            }

            if ((cidade.Id.ToString().Equals("")) || (_cidadeService.PesquisarPorId(cidade.Id) == null))
            {
                return NotFound();
            }

            _cidadeService.Atualizar(cidade);
            return Ok();
        }

        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Exclusão realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a exclusão.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CidadeDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Delete(Guid id)
        {
            CidadeDto cidade = _cidadeService.PesquisarPorId(id);
            if (cidade == null)
            {
                return NotFound();
            }

            _cidadeService.Remover(cidade);
            return Ok();
        }
    }
}