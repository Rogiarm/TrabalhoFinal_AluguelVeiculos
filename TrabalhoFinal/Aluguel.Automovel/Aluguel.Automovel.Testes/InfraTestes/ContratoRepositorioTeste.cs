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
    public class ContratoRepositorioTeste
    {
        private AluguelVeiculoContexto _contextoTeste;
        private ContratoRepositorio _repositorio;
        private VeiculoRepositorio _repositorioVeiculo;
        private Contrato _contratoTest;

       //[SetUp]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<AluguelVeiculoContexto>());

            _contextoTeste = new AluguelVeiculoContexto();

            _repositorio = new ContratoRepositorio();
            _repositorioVeiculo = new VeiculoRepositorio();

            _contratoTest = ConstrutorObjeto.CriarContrato();

            _contextoTeste.Database.Initialize(true);
        }

        //[Test]
        public void Deveria_adicionar_um_novo_contrato()
        {
            //Preparação
            var produto1 = _repositorioVeiculo.BuscarPor(1);

            _contratoTest.Veiculos = new List<Veiculo>();
            _contratoTest.Adiciona(produto1);

            _contratoTest.CalculaTotal();

            //Ação
            _repositorio.Adicionar(_contratoTest);

            //Afirmar
            var todosContratos = _contextoTeste.Contratos.ToList();

           // Assert.AreEqual(2, todosContratos.Count);
        }

        //[Test]
        public void Deveria_deletar_um_contrato()
        {
            //Preparação
            var contratoDeletado = _repositorio.BuscarPor(1);

            //Ação
            _repositorio.Deletar(contratoDeletado);

            //Afirmar
            var todosContratos = _contextoTeste.Contratos.ToList();

            //Assert.AreEqual(0, todosContratos.Count);
        }

        //[Test]
        public void Deveria_buscar_contrato_por_id()
        {

            //Preparação

            //Ação
            var contratoBuscado = _repositorio.BuscarPor(1);

            //Afirmar

            //Assert.IsNotNull(contratoBuscado);
        }

        //[Test]
        public void Deveria_buscar_todos_os_contratos()
        {
            //Preparação

            //Ação
            var contratoBuscado = _repositorio.BuscarTudo();

            //Afirmar

            //Assert.IsNotNull(contratoBuscado);
        }
    }
}
