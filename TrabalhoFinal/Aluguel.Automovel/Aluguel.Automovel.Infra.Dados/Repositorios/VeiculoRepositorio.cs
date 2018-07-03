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
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        public AluguelVeiculoContexto _contexto;

        public VeiculoRepositorio()
        {
            _contexto = new AluguelVeiculoContexto();
        }

        public void Adicionar(Veiculo entidade)
        {
            _contexto.Veiculos.Add(entidade);

            _contexto.SaveChanges();
        }

        public Veiculo BuscarPor(int id)
        {
            return _contexto.Veiculos.Find(id);
        }

        public Veiculo BuscarPorModelo(string modelo)
        {
            return _contexto.Veiculos
                .Where(p => p.Modelo == modelo)
                .FirstOrDefault();
        }

        public List<Veiculo> BuscarTudo()
        {
            return _contexto.Veiculos.ToList();
        }

        public void Deletar(Veiculo entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Veiculos.Attach(entidade);
            }

            _contexto.Veiculos.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Veiculo entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Veiculos.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
