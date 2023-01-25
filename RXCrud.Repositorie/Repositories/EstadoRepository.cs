using Microsoft.EntityFrameworkCore;
using RXCrud.Data.Common;
using RXCrud.Data.Context;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Data;
using System.Linq;

namespace RXCrud.Data.Repositories
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(RXCrudContext context) : base(context)
        {
        }

        public Estado PesquisarPorNome(string nome)
            => _context.Set<Estado>().Where(e => e.Nome.ToUpper().Equals(nome.ToUpper())).AsNoTracking().FirstOrDefault();

    }
}