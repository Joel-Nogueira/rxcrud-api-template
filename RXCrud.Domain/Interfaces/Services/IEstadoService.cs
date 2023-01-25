using RXCrud.Domain.Dto;
using RXCrud.Domain.Interfaces.Common;

namespace RXCrud.Domain.Interfaces.Services
{
    public interface IEstadoService : IService<EstadoDto>
    {
        EstadoDto PesquisarPorNome(string nome);
    }
}