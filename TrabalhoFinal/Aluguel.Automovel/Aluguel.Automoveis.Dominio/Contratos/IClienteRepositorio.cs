using Aluguel.Automoveis.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automoveis.Dominio.Contratos
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Cliente BuscarPorNome(string nome);
    }
}
