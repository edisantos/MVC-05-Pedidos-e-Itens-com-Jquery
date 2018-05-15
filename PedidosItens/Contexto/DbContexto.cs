using PedidosItens.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PedidosItens.Contexto
{
    public class DbContexto: DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Itens> Itens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove < PluralizingTableNameConvention>();
        }
    }
}