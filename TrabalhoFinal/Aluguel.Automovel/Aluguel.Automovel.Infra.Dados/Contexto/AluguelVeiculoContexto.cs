using Aluguel.Automoveis.Dominio.Entidades;
using Aluguel.Automovel.Infra.Dados.Configuracoes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automovel.Infra.Dados.Contexto
{
    public class AluguelVeiculoContexto : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Contrato> Contratos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public AluguelVeiculoContexto() : base("AluguelVeiculosDB")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>()
                .ToTable("TBVeiculo");

            modelBuilder.Entity<Veiculo>()
                .Ignore(p => p.Contrato);

            modelBuilder.Entity<Veiculo>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Veiculo>()
                .Property(p => p.Modelo)
                  .HasColumnType("varchar")
                  .HasMaxLength(150)
                  .IsRequired();

            modelBuilder.Entity<Veiculo>()
                .Property(p => p.Marca)
                  .HasColumnType("varchar")
                  .HasMaxLength(150)
                  .IsRequired();

            modelBuilder.Entity<Veiculo>()
                .Property(p => p.Valor)
                  .IsRequired();

            modelBuilder.Entity<Veiculo>()
                .Property(p => p.TipoCarro)
                  .HasColumnType("tinyint")
                  .IsRequired();

            modelBuilder.Entity<Cliente>()
               .ToTable("TBCliente");

            modelBuilder.Configurations.Add(new ContratoConfiguracao());
        }
    }
}
