using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Common;

namespace RXCrud.Domain.Interfaces.Data
{
    public interface IEstadoRepository : IRepository<Estado>
    {
        Estado PesquisarPorNome(string nome);
    }
}