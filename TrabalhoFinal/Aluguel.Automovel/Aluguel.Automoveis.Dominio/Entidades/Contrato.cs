using Aluguel.Automoveis.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automoveis.Dominio.Entidades
{
    public class Contrato
    {
        public int Id { get; set; }
        public virtual Cliente Cliente { get; set; }
        public double ValorTotal { get; set; }
        public virtual List<Veiculo> Veiculos { get; set; }

        public void Adiciona(Veiculo veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public void Remover(Veiculo veiculo)
        {
            Veiculos.Remove(veiculo);
        }

        public void Validar()
        {
            if (Cliente == null)
                throw new DominioException("Cliente inválido!");
            if (Veiculos == null)
                throw new DominioException("Deve ter pelo menos um veiculo!");
            if (ValorTotal < 0)
                throw new DominioException("Sem Valor total!");
        }

        public void CalculaTotal()
        {
            foreach (var veiculo in Veiculos)
            {
                ValorTotal += veiculo.Valor;
            }
        }
    }
}
