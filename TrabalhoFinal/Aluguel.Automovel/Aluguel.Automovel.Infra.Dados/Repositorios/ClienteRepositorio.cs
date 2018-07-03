using Aluguel.Automoveis.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aluguel.Automoveis.Dominio.Entidades;
using Aluguel.Automovel.Infra.Dados.Contexto;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Aluguel.Automovel.Infra.Dados.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public AluguelVeiculoContexto _contexto;

        public ClienteRepositorio()
        {
            _contexto = new AluguelVeiculoContexto();
        }

        public void Adicionar(Cliente entidade)
        {
            _contexto.Clientes.Add(entidade);

            _contexto.SaveChanges();
        }

        public Cliente BuscarPor(int id)
        {
            return _contexto.Clientes.Find(id);
        }

        public Cliente BuscarPorNome(string nome)
        {
            return _contexto.Clientes
                .Where(p => p.NomeCompleto == nome)
                .FirstOrDefault();
        }

        public List<Cliente> BuscarTudo()
        {
            return _contexto.Clientes.ToList();
        }

        public void Deletar(Cliente entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Clientes.Attach(entidade);
            }

            _contexto.Clientes.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Cliente entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Clientes.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
