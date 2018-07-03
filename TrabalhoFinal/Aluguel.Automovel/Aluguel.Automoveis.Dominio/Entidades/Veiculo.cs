using Aluguel.Automoveis.Dominio.Enums;
using Aluguel.Automoveis.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automoveis.Dominio.Entidades
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public double Valor { get; set; }
        public TipoCarro TipoCarro { get; set; }
        public ICollection<Contrato> Contrato { get; set; }

        public Veiculo()
        {
        }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(Modelo))
                throw new DominioException("Modelo Inválido!");
            if (String.IsNullOrWhiteSpace(Marca))
                throw new DominioException("Marca Inválida!");
            if (Valor < 1)
                throw new DominioException("Valor Inválido!");
            if (TipoCarro < 0)
                throw new DominioException("Tipo Inválido!");
        }
    }
}
