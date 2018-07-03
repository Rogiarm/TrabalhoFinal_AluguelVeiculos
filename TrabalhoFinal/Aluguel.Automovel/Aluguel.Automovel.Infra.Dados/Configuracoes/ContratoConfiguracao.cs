using Aluguel.Automoveis.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automovel.Infra.Dados.Configuracoes
{
    public class ContratoConfiguracao : EntityTypeConfiguration<Contrato>
    {
        public ContratoConfiguracao()
        {
            ToTable("TBContrato");

            HasKey(o => o.Id);

            Property(o => o.ValorTotal)
                .IsRequired();

            HasRequired(a => a.Cliente)
                  .WithMany()
                  .WillCascadeOnDelete(true);

            HasMany(a => a.Veiculos)
                     .WithMany(p => p.Contrato)
                     .Map(cs =>
                     {
                         cs.MapLeftKey("VeiculoId");
                         cs.MapRightKey("ContratoId");
                         cs.ToTable("TBContratoVeiculo");
                     });
        }
    }
}
