using Microsoft.EntityFrameworkCore;
using RXCrud.Data.Configuration;
using RXCrud.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RXCrud.Data.Context
{
    public class RXCrudContext : DbContext
    {
        public RXCrudContext(DbContextOptions<RXCrudContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new EstadoConfig());
            modelBuilder.ApplyConfiguration(new CidadeConfig());

            IList<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario(Guid.Parse("d36edf0e-200a-4732-b5fa-9a850a704a0f"), "Gleryston Matos", "glerystonmatos@rxcrud.com.br", "gleryston", "nQm92qSBD7TDIhkt5co1YA=="));

            modelBuilder.Entity<Usuario>().HasData(usuarios);
        }
    }
}