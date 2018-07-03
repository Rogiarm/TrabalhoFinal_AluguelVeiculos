using Aluguel.Automoveis.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automoveis.Dominio.Contratos
{
    public interface IVeiculoRepositorio : IRepositorio<Veiculo>
    {
        Veiculo BuscarPorModelo(string modelo);
    }
}
