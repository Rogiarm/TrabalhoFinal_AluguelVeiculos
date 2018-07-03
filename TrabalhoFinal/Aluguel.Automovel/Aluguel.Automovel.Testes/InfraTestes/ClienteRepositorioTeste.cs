using Aluguel.Automoveis.Dominio.Entidades;
using Aluguel.Automovel.Infra.Dados.Contexto;
using Aluguel.Automovel.Infra.Dados.Repositorios;
using Aluguel.Automovel.Testes.Base;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automovel.Testes.InfraTestes
{
    //[TestFixure]
    public class ClienteRepositorioTeste
    {
        private AluguelVeiculoContexto _contextoTeste;
        private ClienteRepositorio _repositorio;
        private Cliente _clienteTest;

       //[SetUp]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<AluguelVeiculoContexto>());

            _contextoTeste = new AluguelVeiculoContexto();

            _repositorio = new ClienteRepositorio();

            _clienteTest = ConstrutorObjeto.CriarCliente();

            _contextoTeste.Database.Initialize(true);
        }

        //[Test]
        public void Deveria_adicionar_um_novo_cliente()
        {
            //Preparação

            //Ação
            _repositorio.Adicionar(_clienteTest);

            //Afirmar
            var todosClientes = _contextoTeste.Clientes.ToList();

            //Assert.AreEqual(2, todosClientes.Count);
        }

        //[Test]
        public void Deveria_editar_um_cliente()
        {
            //Preparação
            var clienteEditado = _contextoTeste.Clientes.Find(1);
            clienteEditado.NomeCompleto = "EDITADO";

            //Ação
            _repositorio.Editar(clienteEditado);

            //Afirmar
            var clienteBuscado = _contextoTeste.Clientes.Find(1);

            //Assert.AreEqual("EDITADO", clienteBuscado.NomeCompleto);
        }

        //[Test]
        public void Deveria_deletar_um_cliente()
        {
            //Preparação
            var clienteDeletado = _contextoTeste.Clientes.Find(1);

            //Ação
            _repositorio.Deletar(clienteDeletado);

            //Afirmar
            var todosClientes = _contextoTeste.Clientes.ToList();

            //Assert.AreEqual(0, todosClientes.Count);
        }

        //[Test]
        public void Deveria_buscar_cliente_por_id()
        {

            //Preparação

            //Ação
            var clienteBuscado = _repositorio.BuscarPor(1);

            //Afirmar

            //Assert.IsNotNull(clienteBuscado);
        }

        //[Test]
        public void Deveria_buscar_todos_os_clientes()
        {
            //Preparação

            //Ação
            var clienteBuscado = _repositorio.BuscarTudo();

            //Afirmar

            //Assert.IsNotNull(clienteBuscado);
        }

        //[Test]
        public void Deveria_buscar_cliente_por_nome()
        {
            //Preparação

            //Ação
            var clienteBuscado = _repositorio.BuscarPorNome("Thiago Sator");

            //Afirmar

            //Assert.IsNotNull(clienteBuscado);
        }
    }
}
