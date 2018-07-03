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
    public class ContratoRepositorio : IContratoRepositorio
    {
        public AluguelVeiculoContexto _contexto;

        public ContratoRepositorio()
        {
            _contexto = new AluguelVeiculoContexto();
        }

        public void Adicionar(Contrato entidade)
        {
            _contexto.Contratos.Add(entidade);

            _contexto.SaveChanges();
        }

        public Contrato BuscarPor(int id)
        {
            return _contexto.Contratos.Find(id);
        }

        public List<Contrato> BuscarTudo()
        {
            return _contexto.Contratos.ToList();
        }

        public void Deletar(Contrato entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Contratos.Attach(entidade);
            }

            _contexto.Contratos.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Contrato entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Contratos.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
