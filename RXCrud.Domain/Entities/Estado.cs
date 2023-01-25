using System;
using System.Collections.Generic;

namespace RXCrud.Domain.Entities
{
    public class Estado : Entity
    {
        public Estado(string nome)
        {
            Nome = nome;
            Id = Guid.NewGuid();
        }

        public string Nome { get; set; }

        public ICollection<Cidade> Cidades { get; set; }
    }
}