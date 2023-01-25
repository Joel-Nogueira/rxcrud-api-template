using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Common;
using System;

namespace RXCrud.Domain.Interfaces.Data
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        Cidade PesquisarPorNomeEEstado(string nome, Guid idEstado);
    }
}