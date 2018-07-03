using Aluguel.Automoveis.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automoveis.Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string CNH { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(NomeCompleto))
                throw new DominioException("Nome Inválido!");
            if (String.IsNullOrWhiteSpace(CNH))
                throw new DominioException("CNH Inválida!");
            if (String.IsNullOrWhiteSpace(CPF))
                throw new DominioException("CPF Inválida!");
            if (String.IsNullOrWhiteSpace(Telefone))
                throw new DominioException("Telefone Inválida!");
            if (DataNascimento == new DateTime(0001, 01, 01))
                throw new DominioException("Data nascimento Inválido!");
            if (Endereco == null)
                throw new DominioException("Endereço Inválido!");
        }
    }
}
