using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RXCrud.Domain.Dto
{
    [DisplayName("Estado")]
    public class EstadoDto
    {
        public EstadoDto() 
            => Id = Guid.NewGuid();

        public EstadoDto(string nome)
        {
            Nome = nome;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo 'Nome' obrigatório.")]
        public string Nome { get; set; }
    }
}