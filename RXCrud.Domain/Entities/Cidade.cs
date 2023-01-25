using System;

namespace RXCrud.Domain.Entities
{
    public class Cidade : Entity
    {
        public Cidade(string nome, Guid idEstado)
        {
            Nome = nome;
            Id = Guid.NewGuid();
            IdEstado = idEstado;
        }

        public string Nome { get; set; }

        public Estado Estado { get; set; }

        public Guid IdEstado { get; set; }
    }
}