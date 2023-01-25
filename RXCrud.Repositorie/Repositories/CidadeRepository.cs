using Microsoft.EntityFrameworkCore;
using RXCrud.Data.Common;
using RXCrud.Data.Context;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Data;
using System;
using System.Linq;

namespace RXCrud.Data.Repositories
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(RXCrudContext context) : base(context)
        {
        }

        public Cidade PesquisarPorNomeEEstado(string nome, Guid idEstado)
            => _context.Set<Cidade>().Where(c => c.Nome.ToUpper().Equals(nome.ToUpper()) &&
                c.IdEstado.Equals(idEstado)).AsNoTracking().FirstOrDefault();
    }
}